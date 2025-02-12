using System.Numerics;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
namespace Persistence.DbContexts;

public class NoSQLDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TemplateEntity> Templates { get; init; }

    // public static NoSQLDbContext Create(IMongoDatabase database) =>
    //     new(new DbContextOptionsBuilder<NoSQLDbContext>()
    //         .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
    //         .Options);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TemplateEntity>().ToCollection(name: "templates");
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
    // {
    //     optionsBuilder.Use<Your_SQL_Database_function>("YourConnectionStringHere");
    // }
}
