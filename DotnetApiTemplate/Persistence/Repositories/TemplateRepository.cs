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

        return findResult;
    }
    #endregion

    #region Post
    public async Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity)
    {
        await _context.Templates.AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region Put
    public async Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity)
    {
        TemplateEntity? entity_to_update = await _context.Templates.FindAsync(id);

        if (entity_to_update == null)
        {
            Result<TemplateEntity> errorResult = GenericErrors.NotFoundError(
                entityType: "template",
                id: id
                );
            return errorResult;
        }

        entity.Id = id;

        _context.Templates.Update(entity: entity);

        await _context.SaveChangesAsync();

        return entity;

    }
    #endregion

    #region Delete
    public async Task<Result<TemplateEntity>> DeleteAsync(Guid id)
    {
        TemplateEntity? entity = await _context.Templates.FindAsync(id);

        if (entity == null)
        {
            Result<TemplateEntity> errorResult = GenericErrors.NotFoundError(
                entityType: "template",
                id: id
                );
            return errorResult;
        }

        _context.Templates.Remove(entity: entity);

        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region Patch
    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, List<PatchEntity> patches)
    {

        TemplateEntity? entity = await _context.Templates.FindAsync(id);

        if (entity == null)
        {
            Result<TemplateEntity> errorResult = GenericErrors.NotFoundError(
                entityType: "template",
                id: id
                );
            return errorResult;
        }

        // TODO
        //patchDoc.ApplyTo(car, ModelState);

        return entity;
    }
    #endregion


}
