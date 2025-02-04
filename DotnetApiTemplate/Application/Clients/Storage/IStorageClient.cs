using Domain.Result;

namespace Application.Clients.Storage;

public interface IStorageClient
{
    #region Get
    public Task<Result<Stream>> GetAsync(string path);
    #endregion

    #region Post
    public Task<Result<string>> PostAsync(string path, Stream stream);
    #endregion
}
