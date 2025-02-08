using Domain.Result;
using Application.Clients.Storage;
using Application.Interfaces.Storage;

namespace Application.Services.Storage;

public class StorageService(IStorageClient storageClient, ILogger<StorageService> logger) : IStorageService
{
    private readonly IStorageClient _storageClient = storageClient;
    private readonly ILogger<StorageService> _logger = logger;

    #region Get
    public async Task<Result<FileEntity>> GetAsync(string path)
    {
        return await _storageClient.GetAsync(path: path);
    }
    #endregion

    #region Get
    public async Task<Result<string>> PostAsync(string path, IFormFile file)
    {
        return await _storageClient.PostAsync(path: path, file: file);
    }
    #endregion
}
