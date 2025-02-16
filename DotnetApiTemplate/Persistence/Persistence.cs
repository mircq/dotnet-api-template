using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence.DbContexts;
using Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Application.Repositories;
using MongoDB.Driver;
using System;
using Application.Repositories.SQL;
using Application.Repositories.NoSQL;

namespace Persistence;

public static class Persistence
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        #region SQL Database

        SQLDatabaseSettings SQLDatabaseSettings = new SQLDatabaseSettings();
        configuration.GetSection(key: "SQLDatabaseSettings").Bind(instance: SQLDatabaseSettings);

        services.AddDbContext<SQLDbContext>((IServiceProvider serviceProvider, DbContextOptionsBuilder options) =>
        {
            string SQLconnectionString = $"Host={SQLDatabaseSettings.Host};Port={SQLDatabaseSettings.Port};Database={SQLDatabaseSettings.Name};Username={SQLDatabaseSettings.User};Password={SQLDatabaseSettings.Password};";
            
            options.UseNpgsql(connectionString: SQLconnectionString); 
            
        });

        services.AddScoped<ISQLTemplateRepository, SQLTemplateRepository>();
        #endregion

        #region NoSQL Database

        NoSQLDatabaseSettings noSQLDatabaseSettings = new();
        configuration.GetSection(key: "NoSQLDatabaseSettings").Bind(instance: noSQLDatabaseSettings);

        services.AddDbContext<NoSQLDbContext>((IServiceProvider serviceProvider, DbContextOptionsBuilder options) =>
        {
            string NoSQLConnectionString = $"mongodb://{noSQLDatabaseSettings.User}:{noSQLDatabaseSettings.Password}@{noSQLDatabaseSettings.Host}:{noSQLDatabaseSettings.Port}";
            
            options.UseMongoDB(connectionString: NoSQLConnectionString, databaseName: noSQLDatabaseSettings.Name); 
            
        });

        services.AddScoped<INoSQLTemplateRepository, NoSQLTemplateRepository>();

        #endregion

        

        return services;
    }

}
