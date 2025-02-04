using Infrastructure.Clients;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Keycloak
        KeycloakSettings keycloakSettings = new KeycloakSettings();
        configuration.GetSection("KeycloakSettings").Bind(instance: keycloakSettings);

        services.AddHttpClient<IKeycloakClient, KeycloakClient>();
        #endregion

        #region Storage
        MinIOSettings minIOSettings = new MinIOSettings();
        configuration.GetSection("MinIOSettings").Bind(instance: minIOSettings);

        services.AddSingleton<MinIOSettings>();

        services.AddScoped<IStorageClient, StorageClient>();
        #endregion

        return services;
    }
}
