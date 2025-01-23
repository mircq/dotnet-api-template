namespace Infrastructure.Interfaces;

public interface IRabbitMQClient
{
    public Task<Results<T> Enqueue(); 
}
