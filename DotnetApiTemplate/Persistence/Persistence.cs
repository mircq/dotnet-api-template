using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence.DbContexts;
using Persistence.Settings;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Persistence.Interfaces;

namespace Persistence;

public static class Persistence
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        SQLDatabaseSettings SQLDatabaseSettings = new SQLDatabaseSettings();
        configuration.GetSection("SQLDatabaseSettings").Bind(instance: SQLDatabaseSettings);

        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            string connectionString = $"Host={SQLDatabaseSettings.Host};Port={SQLDatabaseSettings.Port};Database={SQLDatabaseSettings.Name};Username={SQLDatabaseSettings.User};Password={SQLDatabaseSettings.Password};";
            
            // Use the connection string with the appropriate database provider
            options.UseNpgsql(connectionString: connectionString); 
        });

        services.AddScoped<ITemplateRepository, TemplateRepository>();

        return services;
    }

}
