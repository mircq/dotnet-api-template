using Domain.Entities;
using Domain.Result;

namespace Application.Interfaces.Job;

public interface IJobService<T>
{
    public Task<Result<T>> EnqueueAsync(JobEntity entity);
}
