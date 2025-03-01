﻿using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Interfaces.NoSQL;

public interface INoSQLTemplateService
{
    #region Get
    public Task<Result<TemplateEntity>> GetAsync(Guid id);

    #endregion

    #region Post
    public Task<Result<List<TemplateEntity>>> ListAsync(FilterEntity filter);

    public Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);
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
