using Application.Clients.Broker;
using Application.Interfaces.Job;
using Domain.Entities;
using Domain.Result;
using Infrastructure.Interfaces;

namespace Application.Services.Job;

public class JobService<T>(IBrokerClient<T> brokerClient, ILogger<JobService<T>> logger) : IJobService<T>
{
    private readonly IBrokerClient<T> _brokerClient = brokerClient;
    private readonly ILogger<JobService<T>> _logger = logger;

    #region Get
    public async Task<Result<T>> GetAsync(Guid id, bool wait)
    {
        Result<T> result = await _brokerClient.GetAsync(id: id, wait: wait);

        return result;
    }
    #endregion

    #region Post
    public async Task<Result<T>> EnqueueAsync(JobEntity entity)
    {
        _logger.LogInformation(message: "Start");

        Result<T> result = await _brokerClient.EnqueueAsync(entity: entity);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion
}
