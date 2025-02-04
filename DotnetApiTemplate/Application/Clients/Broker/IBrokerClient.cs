using Domain.Entities;
using Domain.Result;

namespace Application.Clients.Broker;

public interface IBrokerClient<T>
{
    public Task<Result<T>> EnqueueAsync(JobEntity entity); 
}
