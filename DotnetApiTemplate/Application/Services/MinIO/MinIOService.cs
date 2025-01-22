using Application.Interfaces.MinIO;
using Application.Services.SQL;
using MongoDB.Driver;
using Persistence.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Clients;
using Domain.Result;

namespace Application.Services.MinIO;

public class MinIOService(IMinIOClient minioClient, ILogger<MinIOService> logger) : IMinIOService
{
    private readonly IMinIOClient _minioClient = minioClient;
    private readonly ILogger<MinIOService> _logger = logger;

    #region Get
    public async Task<Result<Stream>> GetAsync(string path)
    {
        return await _minioClient.GetAsync(path: path);
    }
    #endregion
}
