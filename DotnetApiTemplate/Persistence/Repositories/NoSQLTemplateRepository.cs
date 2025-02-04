using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using MongoDB.Driver;
using Microsoft.AspNetCore.JsonPatch;
using Persistence.DbContexts;
using Application.Repositories.NoSQL;

namespace Persistence.Repositories;

public class NoSQLTemplateRepository(NoSQLDbContext context, IMongoDatabase database, string collectionName): INoSQLTemplateRepository
{
    private readonly IMongoCollection<TemplateEntity> _collection = database.GetCollection<TemplateEntity>(name: collectionName);
    private readonly NoSQLDbContext _context = context;

    #region Get
    public async Task<Result<TemplateEntity>> GetAsync(Guid id)
    {
        FilterDefinition<TemplateEntity> filter = Builders<TemplateEntity>.Filter.Eq("_id", id);
        TemplateEntity result = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (result == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: id);
        }

        return result;

    }
    #endregion

    #region Post

    public async Task<Result<TemplateEntity>> CreateAsync(TemplateEntity entity)
    {
        await _collection.InsertOneAsync(document: entity);

        FilterDefinition<TemplateEntity> filter = Builders<TemplateEntity>.Filter.Eq("_id", entity.Id);

        TemplateEntity? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: entity.Id);
        }

        return findResult;
    }
    #endregion

    #region Put
    public async Task<Result<TemplateEntity>> UpdateAsync(Guid id, TemplateEntity entity)
    {
        FilterDefinition<TemplateEntity> filter = Builders<TemplateEntity>.Filter.Eq("_id", id);

        TemplateEntity? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: id);
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
    public async Task<Result<TemplateEntity>> DeleteAsync(Guid id)
    {
        FilterDefinition<TemplateEntity> filter = Builders<TemplateEntity>.Filter.Eq("_id", id);

        TemplateEntity? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: id);
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
    public async Task<Result<TemplateEntity>> PatchAsync(Guid id, JsonPatchDocument patchDocument)
    {
        FilterDefinition<TemplateEntity> filter = Builders<TemplateEntity>.Filter.Eq("_id", id);

        TemplateEntity? findResult = await _collection.Find(filter: filter).FirstOrDefaultAsync();

        if (findResult == null)
        {
            return GenericErrors.NotFoundError(entityType: "template", id: id);
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

    public Task<Result<TemplateEntity>> PostAsync(TemplateEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TemplateEntity>> PutAsync(Guid id, TemplateEntity entity)
    {
        throw new NotImplementedException();
    }
    #endregion
}
