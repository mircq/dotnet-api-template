using System;
using Application.Interfaces;
using Domain.Entities;
using Domain.Result;

namespace Application.Services.Template;

public class TemplateService: ITemplateService
{

    private readonly ICarRepository _carRepository;

    #region Get

    public async Result<TemplateEntity> GetAsync(Guid id)
    {
        Result<TemplateEntity> result = await ITemplateRepository.GetAsync(id: id);

        return result;
    }
    #endregion

    #region Post
    public Result<TemplateEntity> PostAsync(TemplateEntity entity)
    {
        Result<TemplateEntity> result = await ITemplateRepository.PostAsync(entity: entity);

        return result;
    }
    #endregion

    #region Put

    public Result<TemplateEntity> PutAsync(Guid id, TemplateEntity entity)
    {
        Result<TemplateEntity> result = await ITemplateRepository.PutAsync(id: id, entity: entity);

        return result;
    }
    #endregion

    #region Delete

    public Result<TemplateEntity> DeleteAsync(Guid id)
    {
        Result<TemplateEntity> result = await ITemplateRepository.DeleteAsync(id: id);

        return result;
    }
    #endregion

    #region Patch

    public Result<TemplateEntity> PatchAsync(Guid id, List<PatchEntity> patches)
    {
        Result<TemplateEntity> result = await ITemplateRepository.PatchAsync(id: id, patches: patches);

        return result;
    }
    #endregion
}
