using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Repositories.NoSQL;

public interface INoSQLTemplateRepository
{
    #region Get
    Task<Result<TemplateEntity>> GetAsync(Guid id);
    #endregion

    #region Post
    Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);

    Task<Result<List<TemplateEntity>>> ListAsync(FilterEntity filter);
    #endregion

    #region Put
    Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity);
    #endregion

    #region Delete
    Task<Result<TemplateEntity>> DeleteAsync(Guid id);
    #endregion

    #region Patch
    Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument);
    #endregion
}
