using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;
using Persistence.Interfaces;

namespace Persistence.Repositories;

public class SQLTemplateRepository(SQLDbContext context) : ISQLTemplateRepository
{

    private readonly SQLDbContext _context = context;

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
    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
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

        patchDocument.ApplyTo(objectToApplyTo: entity);

        return entity;
    }
    #endregion


}
