using Domain.Entities;
using Domain.Result;

namespace Infrastructure.Interfaces;

public interface IRabbitMQClient<T>
{
    public Task<Result<T>> EnqueueAsync(JobEntity entity); 
}
