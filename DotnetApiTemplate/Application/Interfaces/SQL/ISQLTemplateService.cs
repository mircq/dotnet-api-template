using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Interfaces.SQL;

public interface ISQLTemplateService
{
    #region Get
    public Task<Result<TemplateEntity>> GetAsync(Guid id);

    #endregion

    #region Post
    public Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);

    public Task<Result<List<TemplateEntity>>> ListAsync(FilterEntity filter);
    #endregion

    #region Put
    public Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity);
    #endregion

    #region Delete
    public Task<Result<TemplateEntity>> DeleteAsync(Guid id);
    #endregion

    #region Patch
    public Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument);
    #endregion
}
