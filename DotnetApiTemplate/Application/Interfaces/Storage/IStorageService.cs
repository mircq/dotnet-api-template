using Domain.Result;

namespace Application.Interfaces.Storage;

public interface IStorageService
{
    #region Get
    public Task<Result<FileEntity>> GetAsync(string path);
    #endregion

    #region Post
    public Task<Result<FileEntity>> PostAsync(string path, IFormFile file);
    #endregion

    #region Delete
    public Task<Result<FileEntity>> DeleteAsync(string path);
    #endregion
}
