using Domain.Result;
using Infrastructure.Clients;

namespace Infrastructure.Interfaces;

public interface IMinIOClient
{
    #region Get
    public Task<Result<Stream>> GetAsync(string path);
    #endregion

    #region Post
    public Task<Result<string>> PostAsync(string path, Stream stream);
    #endregion
}
