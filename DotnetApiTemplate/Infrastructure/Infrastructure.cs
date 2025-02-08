using Application.Clients.Storage;
using Infrastructure.Clients;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Settings.Storage;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Keycloak
        KeycloakSettings keycloakSettings = new();
        configuration.GetSection(key: "KeycloakSettings").Bind(instance: keycloakSettings);

        services.AddHttpClient<IKeycloakClient, KeycloakClient>();
        #endregion

        #region Storage
        StorageSettings storageSettings = new();
        configuration.GetSection(key: "StorageSettings").Bind(instance: storageSettings);

        services.AddSingleton(storageSettings);

        services.AddScoped<IStorageClient, StorageClient>();
        #endregion

        return services;
    }
}
