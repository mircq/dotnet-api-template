using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;
using Persistence.DbContexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class MongoRepository<T>(NoSQLDbContext context, IMongoDatabase database, string collectionName) where T : BaseEntity
{
    private readonly IMongoCollection<T> _collection = database.GetCollection<T>(name: collectionName);
    private readonly NoSQLDbContext _context = context;

    #region Get
    public async Task<Result<T>> GetAsync(Guid id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);
        T result = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (result == null)
        {
            return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        }

        return result;
    }
    #endregion
    
    
    #region Post
    public async Task<Result<T>> CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(document: entity);

        FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: entity.Id);

        T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: entity.Id);
        }

        return findResult;

        //await _context.AddAsync<T>(entity);

        //await _context.Templates.AddAsync(entity: entity);
    }
    #endregion

    #region Put
    public async Task<Result<T>> UpdateAsync(Guid id, T entity)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        }

        ReplaceOneResult updateResult = await _collection.ReplaceOneAsync(filter: filter, replacement: entity);

        if (updateResult.ModifiedCount == 0)
        {
            return GenericErrors.GenericError(message: "An error occurred while replacing the template.");
        }

        entity.Id = id;

        return entity;
    }
    #endregion

    #region Delete
    public async Task<Result<T>> DeleteAsync(Guid id)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        }

        DeleteResult result = await _collection.DeleteOneAsync(filter: filter);

        if (result.DeletedCount == 0)
        {
            return GenericErrors.GenericError(message: "An error occurred while deleting the template.");
        }

        return findResult;
    }
    #endregion
    

    #region Patch
    public async Task<Result<T>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
    {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq(field: "_id", value: id);

        T? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: typeof(T).Name, id: id);
        }

        patchDocument.ApplyTo(objectToApplyTo: findResult);

        ReplaceOneResult updateResult = await _collection.ReplaceOneAsync(filter: filter, replacement: findResult);

        if (updateResult.ModifiedCount == 0)
        {
            return GenericErrors.GenericError(message: "An error occurred while replacing the template.");
        }

        findResult.Id = id;

        return findResult;
    }
    #endregion
}