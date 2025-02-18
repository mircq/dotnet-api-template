using Infrastructure.Settings;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text.Json;
using Domain.Result;
using Newtonsoft.Json;
using Domain.Entities;
using Application.Clients.Broker;
using Domain.Errors;
using Infrastructure.Settings.Broker;

namespace Infrastructure.Clients;

public class BrokerClient<T>: IBrokerClient<T>
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly string _queueName;
    private readonly ILogger<BrokerClient<T>> _logger;

    public BrokerClient(BrokerSettings settings)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = $"{settings.Host}/{settings.Port}",
            UserName = settings.User,
            Password = settings.Password
        };

        _queueName = settings.QueueName;
    }

    #region Get
    public async Task<Result<T>> GetAsync(Guid id, bool wait)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: id={id}, wait={wait}");

        using IConnection connection = await _connectionFactory.CreateConnectionAsync();
        using IChannel channel = await connection.CreateChannelAsync();

        switch(wait)
        {
            case true:
                BasicGetResult? getResult = await channel.BasicGetAsync(queue: id.ToString(), autoAck: true);

                if (getResult != null)
                {
                    _logger.LogDebug(message: "Message received.");

                    byte[] body = getResult.Body.ToArray();
                    string message = Encoding.UTF8.GetString(bytes: body);

                    _logger.LogDebug(message: "Message correctly deserialized.");

                    Result<T> result = JsonConvert.DeserializeObject<Result<T>>(value: message);

                    return result;
                }

                return GenericErrors.NotFoundError(entityType: "job", id: id);
            case false:
                await channel.QueueDeclareAsync(
                    queue: id.ToString(),
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                TaskCompletionSource<Result<T>> responseTcs = new TaskCompletionSource<Result<T>>();

                AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel: channel);
                consumer.ReceivedAsync += (object model, BasicDeliverEventArgs ea) =>
                {
                    _logger.LogDebug(message: "Message received.");

                    byte[] body = ea.Body.ToArray();
                    string message = Encoding.UTF8.GetString(bytes: body);

                    Result<T> result = JsonConvert.DeserializeObject<Result<T>>(value: message);

                    _logger.LogDebug(message: "Message correctly deserialized.");

                    responseTcs.SetResult(result: result);

                    return Task.CompletedTask;
                };

                await channel.BasicConsumeAsync(queue: id.ToString(), autoAck: true, consumer: consumer);

                _logger.LogInformation(message: "End");

                return await responseTcs.Task;
        }
    }
    #endregion

    # region Post
    public async Task<Result<Guid>> EnqueueAsync(JobEntity entity)
    {
        using IConnection connection = await _connectionFactory.CreateConnectionAsync();
        using IChannel channel = await connection.CreateChannelAsync();

        // Create a correlation ID for tracking responses
        Guid correlationId = Guid.NewGuid();

        #region Send
        await channel.QueueDeclareAsync(
            queue: _queueName, 
            durable: false, 
            exclusive: false, 
            autoDelete: false,
            arguments: null
        );

        Dictionary<string, object> dictionary = new()
        {
            { "function_name", entity.FunctionName },
            { "response_queue", correlationId },
            { "args", entity.Args },
            { "kwargs", entity.Kwargs },
        };

        string dictionaryString = System.Text.Json.JsonSerializer.Serialize(value: dictionary);

        //Convert JSON string to bytes
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s: dictionaryString);

        await channel.BasicPublishAsync(
             exchange: string.Empty, routingKey: _queueName, body: bytes);

        return correlationId;

        // #endregion

        // #region Receive

        // await channel.QueueDeclareAsync(
        //     queue: correlationId.ToString(), 
        //     durable: false, 
        //     exclusive: false, 
        //     autoDelete: false,
        //     arguments: null
        // );

        // var responseTcs = new TaskCompletionSource<Result<T>>();

        // AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel: channel);
        // consumer.ReceivedAsync += (model, ea) =>
        // {
        //     byte[] body = ea.Body.ToArray();
        //     string message = Encoding.UTF8.GetString(bytes: body);

        //     Result<T> result = JsonConvert.DeserializeObject<Result<T>>(value: message);

        //     Console.WriteLine($" [x] Received {message}");
        //     responseTcs.SetResult(result);

        //     return Task.CompletedTask;
        // };

        // await channel.BasicConsumeAsync(queue: correlationId, autoAck: true, consumer: consumer);

        // return await responseTcs.Task;
        #endregion
    }

    #endregion
}
