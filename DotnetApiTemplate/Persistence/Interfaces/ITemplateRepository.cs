using Domain.Entities;
using Domain.Result;

namespace Persistence.Interfaces;

public interface ITemplateRepository
{
    #region Get
    Task<Result<TemplateEntity>> GetAsync(Guid id);
    #endregion

    #region Post
    Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);
    #endregion

    #region Put
    Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity);
    #endregion

    #region Delete
    Task<Result<TemplateEntity>> DeleteAsync(Guid id);
    #endregion

    #region Patch
    Task<Result<TemplateEntity>> PatchAsync(Guid id, List<PatchEntity> patches);
    #endregion

}
