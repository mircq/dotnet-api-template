﻿using Application.Interfaces.SQL;
using Application.Repositories.SQL;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services.SQL;

public class SQLTemplateService(ISQLTemplateRepository templateRepository, ILogger<SQLTemplateService> logger) : ISQLTemplateService
{
    private readonly ISQLTemplateRepository _templateRepository = templateRepository;
    private readonly ILogger<SQLTemplateService> _logger = logger;

    #region Get

    public async Task<Result<TemplateEntity>> GetAsync(Guid id)
    {
        _logger.LogInformation(message: $"Start");
        _logger.LogDebug(message: $"Input params: id={id}");

        Result<TemplateEntity> result = await _templateRepository.GetAsync(id: id);

        _logger.LogInformation(message: "End");

        return result;
    }

    public async Task<Result<List<TemplateEntity>>> ListAsync(FilterEntity filter)
    {
        _logger.LogInformation(message: $"Start");
        _logger.LogDebug(message: $"Input params: filter={filter}");

        Result<List<TemplateEntity>> result = await _templateRepository.ListAsync(filter: filter);

        _logger.LogInformation(message: "End");

        return result;
    }

    #endregion

    #region Post
    public async Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity)
    {

        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: entity={entity}");

        Result<TemplateEntity> result = await _templateRepository.PostAsync(entity: entity);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion

    #region Put

    public async Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: id={id}, entity={entity}");

        Result<TemplateEntity> result = await _templateRepository.PutAsync(id: id, entity: entity);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion

    #region Delete

    public async Task<Result<TemplateEntity>> DeleteAsync(Guid id)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: id={id}");

        Result<TemplateEntity> result = await _templateRepository.DeleteAsync(id: id);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion

    #region Patch

    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
    {
        _logger.LogInformation(message: "Start");
        _logger.LogDebug(message: $"Input params: id={id}, patchDocument={patchDocument}");

        Result<TemplateEntity> result = await _templateRepository.PatchAsync(id: id, patchDocument: patchDocument);

        _logger.LogInformation(message: "End");

        return result;
    }
    #endregion
}
