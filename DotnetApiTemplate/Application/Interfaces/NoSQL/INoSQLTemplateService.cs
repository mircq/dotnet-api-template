using Domain.Entities;
using Domain.Result;

namespace Application.Interfaces.NoSQL;

public interface INoSQLTemplateService
{
    #region Get
    public Task<Result<TemplateEntity>> GetAsync(Guid id);

    public Task<Result<TemplateEntity>> ListAsync();
    #endregion

    #region Post
    public Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);
    #endregion

    #region Put
    public Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity);
    #endregion

    #region Delete
    public Task<Result<TemplateEntity>> DeleteAsync(Guid id);
    #endregion

    #region Patch
    public Task<Result<TemplateEntity>> PatchAsync(Guid id, List<PatchEntity> patches);
    #endregion
}
