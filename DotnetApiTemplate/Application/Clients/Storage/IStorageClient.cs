using Domain.Result;

namespace Application.Clients.Storage;

public interface IStorageClient
{
    #region Get
    public Task<Result<FileEntity>> GetAsync(string path);
    #endregion

    #region Post
    public Task<Result<string>> PostAsync(string path, IFormFile file);
    #endregion
}
