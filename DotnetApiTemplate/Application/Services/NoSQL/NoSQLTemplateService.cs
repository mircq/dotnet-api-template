﻿using Application.Interfaces.NoSQL;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;
using Persistence.Interfaces;

namespace Application.Services.NoSQL;

public class NoSQLTemplateService: INoSQLTemplateService
{
    private readonly INoSQLTemplateRepository _templateRepository;

    #region Get

    public async Task<Result<TemplateEntity>> GetAsync(Guid id)
    {
        Result<TemplateEntity> result = await _templateRepository.GetAsync(id: id);

        return result;
    }

    public async Task<Result<TemplateEntity>> ListAsync()
    {   
        // TODO
        throw new NotImplementedException();
    }

    #endregion

    #region Post
    public async Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity)
    {
        Result<TemplateEntity> result = await _templateRepository.PostAsync(entity: entity);

        return result;
    }
    #endregion

    #region Put

    public async Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity)
    {
        Result<TemplateEntity> result = await _templateRepository.PutAsync(id: id, entity: entity);

        return result;
    }
    #endregion

    #region Delete

    public async Task<Result<TemplateEntity>> DeleteAsync(Guid id)
    {
        Result<TemplateEntity> result = await _templateRepository.DeleteAsync(id: id);

        return result;
    }
    #endregion

    #region Patch

    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
    {
        Result<TemplateEntity> result = await _templateRepository.PatchAsync(id: id, patchDocument: patchDocument);

        return result;
    }
    #endregion
}
