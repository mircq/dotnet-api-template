using Application.Repositories.SQL;
using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Domain.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;


namespace Persistence.Repositories;

public class SQLBaseRepository<T>(SQLDbContext context) where T: BaseEntity
{
    private readonly SQLDbContext _context = context;

    #region Get
    public async Task<Result<T>> GetAsync(Guid id)
    {

        T? findResult = await _context.Set<T>().FindAsync(id);

        if (findResult == null)
        {
            Result<T> errorResult = GenericErrors.NotFoundError(
                entityType: typeof(T).Name,
                id: id
                );
            return errorResult;
        }

        return findResult;
    }
    #endregion

    #region Post

    public async Task<Result<List<T>>> ListAsync(FilterEntity filter)
    {
        Result<List<T>> result = await _context.Set<T>().AsQueryable()
            .ApplyFilters(filters: filter.filters)
            .ApplySorting(sortField: filter.SortField, sortOrder: filter.SortOrder)
            .ApplyPagination(pageSize: filter.PageSize, pageNumber: filter.PageNumber)
            .ToListAsync();

        return result;
    }

    public async Task<Result<T>> PostAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region Put
    public async Task<Result<T>> PutAsync(Guid id, T entity)
    {
        T? entity_to_update = await _context.Set<T>().FindAsync(id);

        if (entity_to_update == null)
        {
            Result<T> errorResult = GenericErrors.NotFoundError(
                entityType: typeof(T).Name,
                id: id
                );
            return errorResult;
        }

        entity.Id = id;

        _context.Set<T>().Update(entity: entity);

        await _context.SaveChangesAsync();

        return entity;

    }
    #endregion

    #region Delete
    public async Task<Result<T>> DeleteAsync(Guid id)
    {
        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            Result<T> errorResult = GenericErrors.NotFoundError(
                entityType: typeof(T).Name,
                id: id
                );
            return errorResult;
        }

        _context.Set<T>().Remove(entity: entity);

        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion

    #region Patch
    public async Task<Result<T>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
    {

        T? entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            Result<T> errorResult = GenericErrors.NotFoundError(
                entityType: typeof(T).Name,
                id: id
                );
            return errorResult;
        }

        patchDocument.ApplyTo(objectToApplyTo: entity);

        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion


}
