using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class TemplateRepository: ITemplateRepository
{

    private readonly AppDbContext _context;

    public TemplateRepository(AppDbContext context)
    {
        _context = context;
    }

    #region Get
    public async Task<Result<TemplateEntity>> GetAsync(Guid id)
    {

        TemplateEntity? findResult = await _context.Templates.FindAsync(id);

        if (findResult == null)
        {
            Result<TemplateEntity> errorResult = GenericErrors.NotFoundError(
                entityType: "template",
                id: id
                );
            return errorResult;
        }

        Result<TemplateEntity> successfulResult = findResult;

        return successfulResult;
    }
    #endregion

    #region Post
    public async Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity)
    {
        return await _context.Templates.AddAsync(entity);
    }
    #endregion

    #region Put
    public async Result<TemplateEntity> PutAsync(Guid id, TemplateEntity entity)
    {

    }
    #endregion

    #region Delete
    public async Result<TemplateEntity> DeleteAsync(Guid id)
    {
        TemplateEntity? findResult = await _context.Templates.ExecuteDeleteAsync(id);
    }
    #endregion

    #region Patch
    public async Result<TemplateEntity> PatchAsync(Guid id, TemplateEntity entity)
    {

    }
    #endregion


}
