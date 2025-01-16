using System;
using Domain.Entities;
using Domain.Result;

namespace Application.Interfaces;

public interface ITemplateService
{

    #region Get
    public Task<Result<TemplateEntity>> GetAsync(Guid id);
    #endregion

    #region Post
    public Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity);
    #endregion
}
