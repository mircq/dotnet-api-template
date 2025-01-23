using Infrastructure.Settings;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Infrastructure.Clients;

public class RabbitMQClient
{
    private readonly ConnectionFactory _connectionFactory;

    public RabbitMQClient(RabbitMQSettings settings)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = $"{settings.Host}/{settings.Port}",
            UserName = settings.Username,
            Password = settings.Password
        };
    }

    public async Task<string> SendMessageAsync(string queueName, string message)
    {
        using IConnection connection = await _connectionFactory.CreateConnectionAsync();
        using IChannel channel = await connection.CreateChannelAsync();

        // Create a correlation ID for tracking responses
        string correlationId = Guid.NewGuid().ToString();

        #region Send
        await channel.QueueDeclareAsync(queue: queueName, durable: false, exclusive: false, autoDelete: false,
        arguments: null);

        Dictionary<string, object> dict = new Dictionary<string, object>()
        {
            { "function_name", "function_name" },
            { "response_queue", correlationId },
            { "args", new List<object>() },
            { "kwargs", new Dictionary<string, object>() },
        };

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: string.Empty, routingKey: queueName, body: body);


        #endregion

        #region Receive

        await channel.QueueDeclareAsync(queue: correlationId, durable: false, exclusive: false, autoDelete: false,
    arguments: null);

        AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel: channel);
        consumer.ReceivedAsync += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
            return Task.CompletedTask;
        };

        await channel.BasicConsumeAsync("hello", autoAck: true, consumer: consumer);

        #endregion



        // Wait for the response
        return await responseTaskCompletionSource.Task;
    }
}
