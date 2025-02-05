using Application.Interfaces.NoSQL;
using Application.Interfaces.SQL;
using Application.Interfaces.Storage;
using Application.Services.NoSQL;
using Application.Services.SQL;
using Application.Services.Storage;

namespace Application;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Services

        services.AddScoped<ISQLTemplateService, SQLTemplateService>();
        services.AddScoped<INoSQLTemplateService, NoSQLTemplateService>();
        services.AddScoped<IStorageService, StorageService>();

        #endregion

        return services;
    }
}
