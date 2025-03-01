namespace Infrastructure.Settings.Broker;

public class BrokerSettings
{
    public string Host { get; set; }

    public int Port { get; set; }

    public string User { get; set; }

    public string Password { get; set; }

    public string QueueName { get; set; }
}
