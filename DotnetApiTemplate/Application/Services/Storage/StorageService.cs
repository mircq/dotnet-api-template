using Application.Interfaces.MinIO;
using Domain.Result;
using Application.Clients.Storage;

namespace Application.Services.Storage;

public class StorageService(IStorageClient storageClient, ILogger<StorageService> logger) : IMinIOService
{
    private readonly IStorageClient _storageClient = storageClient;
    private readonly ILogger<StorageService> _logger = logger;

    #region Get
    public async Task<Result<Stream>> GetAsync(string path)
    {
        return await _storageClient.GetAsync(path: path);
    }
    #endregion

    #region Get
    public async Task<Result<string>> PostAsync(string path, Stream stream)
    {
        return await _storageClient.PostAsync(path: path, stream: stream);
    }
    #endregion
}
