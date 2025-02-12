using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Domain.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Persistence.DbContexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class NoSQLBaseRepository<T>(NoSQLDbContext context) where T : TemplateEntity
{
    private readonly NoSQLDbContext _context = context;

    #region Get
    public virtual async Task<Result<T>> GetAsync(Guid id)
    {

        T? findResult = await _context.Set<T>().FindAsync(id);

        // FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);
        // T result = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        }

        return findResult;
    }
    #endregion
    
    
    #region Post

    public virtual async Task<Result<List<T>>> ListAsync(FilterEntity filter)
    {
        Result<List<T>> result = await _context.Set<T>().AsQueryable()
            .ApplyFilters(filters: filter.filters)
            .ApplySorting(sortField: filter.SortField, sortOrder: filter.SortOrder)
            .ApplyPagination(pageSize: filter.PageSize, pageNumber: filter.PageNumber)
            .ToListAsync();

        return result;
    }

    public virtual async Task<Result<T>> PostAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;

        // await _collection.InsertOneAsync(document: entity);

        // FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: entity.Id);

        // T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        // if (findResult == null)
        // {
        //     return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: entity.Id);
        // }

        // return findResult;

        //await _context.AddAsync<T>(entity);

        //await _context.Templates.AddAsync(entity: entity);
    }
    #endregion

    #region Put
    public virtual async Task<Result<T>> PutAsync(Guid id, T entity)
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

        // TODO can be done in a better way?
        _context.Set<T>().Remove(entity: entity_to_update);

        await _context.Set<T>().AddAsync(entity: entity);

        await _context.SaveChangesAsync();

        return entity;

        // FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        // T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        // if (findResult == null)
        // {
        //     return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        // }

        // ReplaceOneResult updateResult = await _collection.ReplaceOneAsync(filter: filter, replacement: entity);

        // if (updateResult.ModifiedCount == 0)
        // {
        //     return GenericErrors.GenericError(message: "An error occurred while replacing the template.");
        // }

        // entity.Id = id;

        // return entity;
    }
    #endregion

    #region Delete
    public virtual async Task<Result<T>> DeleteAsync(Guid id)
    {
        // FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        // T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        // if (findResult == null)
        // {
        //     return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        // }

        // DeleteResult result = await _collection.DeleteOneAsync(filter: filter);

        // if (result.DeletedCount == 0)
        // {
        //     return GenericErrors.GenericError(message: "An error occurred while deleting the template.");
        // }

        // return findResult;

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
    public virtual async Task<Result<T>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
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

        // FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        // T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        // if (findResult == null)
        // {
        //     return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        // }

        // patchDocument.ApplyTo(objectToApplyTo: findResult);

        // ReplaceOneResult updateResult = await _collection.ReplaceOneAsync(filter: filter, replacement: findResult);

        // if (updateResult.ModifiedCount == 0)
        // {
        //     return GenericErrors.GenericError(message: "An error occurred while replacing the template.");
        // }

        // findResult.Id = id;

        // return findResult;
    }
    #endregion
}