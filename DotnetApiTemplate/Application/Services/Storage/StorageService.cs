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
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: path={path}");

        Result<FileEntity> result = await _storageClient.GetAsync(path: path);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion

    #region Post
    public async Task<Result<FileEntity>> PostAsync(string path, IFormFile file)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: path={path}, file=file of size {file.Length} bytes");

        Result<FileEntity> result = await _storageClient.PostAsync(path: path, file: file);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion

    #region Delete
    public async Task<Result<FileEntity>> DeleteAsync(string path)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: path={path}");

        Result<FileEntity> result = await _storageClient.DeleteAsync(path: path);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion
}
