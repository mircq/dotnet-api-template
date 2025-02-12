using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using MongoDB.Driver;
using Microsoft.AspNetCore.JsonPatch;
using Persistence.DbContexts;
using Application.Repositories.NoSQL;

namespace Persistence.Repositories;

public class NoSQLTemplateRepository(NoSQLDbContext context): NoSQLBaseRepository<TemplateEntity>(context: context), INoSQLTemplateRepository
{
}
