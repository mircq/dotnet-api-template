using Application.Interfaces.Job;
using Application.Services.MinIO;
using Domain.Entities;
using Domain.Result;
using Infrastructure.Interfaces;

namespace Application.Services.Job;

public class JobService<T>(IRabbitMQClient<T> rabbitClient, ILogger<MinIOService> logger) : IJobService<T>
{
    private readonly IRabbitMQClient<T> _rabbitClient = rabbitClient;
    private readonly ILogger<MinIOService> _logger = logger;

    #region Get
    public async Task<Result<T>> GetAsync(Guid id)
    {
        throw new NotImplementedException(),
    }
    #endregion

    #region Post
    public async Task<Result<T>> EnqueueAsync(JobEntity entity)
    {
        _logger.LogInformation(message: "Start");

        Result<T> result = await _rabbitClient.EnqueueAsync(entity: entity);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion
}
