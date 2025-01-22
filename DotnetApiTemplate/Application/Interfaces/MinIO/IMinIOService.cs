using Domain.Result;
using Infrastructure.Clients;

namespace Application.Interfaces.MinIO;

public interface IMinIOService
{
    #region Get
    public Task<Result<Stream>> GetAsync(string path);
    #endregion

    #region Post
    #endregion
}
