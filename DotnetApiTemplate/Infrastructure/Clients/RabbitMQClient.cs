using Infrastructure.Settings;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text.Json;
using Domain.Result;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using Domain.Entities;

namespace Infrastructure.Clients;

public class RabbitMQClient<T>: IRabbitMQClient<T>
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly string _queueName;

    public RabbitMQClient(RabbitMQSettings settings)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = $"{settings.Host}/{settings.Port}",
            UserName = settings.Username,
            Password = settings.Password
        };

        _queueName = settings.QueueName;
    }

    public async Task<Result<T>> EnqueueAsync(JobEntity entity)
    {
        using IConnection connection = await _connectionFactory.CreateConnectionAsync();
        using IChannel channel = await connection.CreateChannelAsync();

        // Create a correlation ID for tracking responses
        string correlationId = Guid.NewGuid().ToString();

        #region Send
        await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false,
        arguments: null);

        Dictionary<string, object> dictionary = new Dictionary<string, object>()
        {
            { "function_name", entity.FunctionName },
            { "response_queue", correlationId },
            { "args", entity.Args },
            { "kwargs", entity.Kwargs },
        };

        string dictionaryString = System.Text.Json.JsonSerializer.Serialize(value: dictionary);

        // Convert JSON string to bytes
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s: dictionaryString);

        await channel.BasicPublishAsync(
            exchange: string.Empty, routingKey: _queueName, body: bytes);


        #endregion

        #region Receive

        await channel.QueueDeclareAsync(
            queue: correlationId, 
            durable: false, 
            exclusive: false, 
            autoDelete: false,
            arguments: null
        );

        var responseTcs = new TaskCompletionSource<Result<T>>();

        AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel: channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            byte[] body = ea.Body.ToArray();
            string message = Encoding.UTF8.GetString(bytes: body);

            Result<T> result = JsonConvert.DeserializeObject<Result<T>>(value: message);

            Console.WriteLine($" [x] Received {message}");
            responseTcs.SetResult(result);

            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync(queue: correlationId, autoAck: true, consumer: consumer);

        return await responseTcs.Task;
        #endregion
    }
}
