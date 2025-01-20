using Application.Interfaces.SQL;
using Domain.Entities;
using Domain.Result;
using Persistence.Interfaces;

namespace Application.Services.SQL;

public class SQLTemplateService(ITemplateRepository templateRepository) : ISQLTemplateService
{
    private readonly ITemplateRepository _templateRepository = templateRepository;

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

    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, List<PatchEntity> patches)
    {
        Result<TemplateEntity> result = await _templateRepository.PatchAsync(id: id, patches: patches);

        return result;
    }
    #endregion
}
