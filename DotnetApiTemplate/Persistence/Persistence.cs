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

namespace Persistence;

public static class Persistence
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        #region SQL Database

        SQLDatabaseSettings SQLDatabaseSettings = new SQLDatabaseSettings();
        configuration.GetSection("SQLDatabaseSettings").Bind(instance: SQLDatabaseSettings);

        services.AddDbContext<SQLDbContext>((serviceProvider, options) =>
        {
            string SQLconnectionString = $"Host={SQLDatabaseSettings.Host};Port={SQLDatabaseSettings.Port};Database={SQLDatabaseSettings.Name};Username={SQLDatabaseSettings.User};Password={SQLDatabaseSettings.Password};";
            
            // Use the connection string with the appropriate database provider
            options.UseNpgsql(connectionString: SQLconnectionString); 
        });

        #endregion

        #region NoSQL Database

        NoSQLDatabaseSettings noSQLDatabaseSettings = new NoSQLDatabaseSettings();
        configuration.GetSection("NoSQLDatabaseSettings").Bind(instance: noSQLDatabaseSettings);

        string NoSQLConnectionString = $"mongodb://{noSQLDatabaseSettings.User}:{noSQLDatabaseSettings.Password}@{noSQLDatabaseSettings.Host}:{noSQLDatabaseSettings.Port}";

        MongoClient client = new MongoClient(connectionString: NoSQLConnectionString);
        IMongoDatabase database = client.GetDatabase(noSQLDatabaseSettings.Name);

        services.AddSingleton(database);

        #endregion

        services.AddScoped<ISQLTemplateRepository, SQLTemplateRepository>();

        return services;
    }

}
