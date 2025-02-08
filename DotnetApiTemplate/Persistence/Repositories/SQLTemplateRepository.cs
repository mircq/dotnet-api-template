using Application.Repositories.SQL;
using Domain.Entities;
using Domain.Errors;
using Domain.Result;
using Domain.Utils;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;


namespace Persistence.Repositories;

public class SQLTemplateRepository(SQLDbContext context) : SQLBaseRepository<TemplateEntity>(context: context), ISQLTemplateRepository 
{
}
