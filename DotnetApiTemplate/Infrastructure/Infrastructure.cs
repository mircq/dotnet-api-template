using Infrastructure.Clients;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class Infrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        KeycloakSettings keycloakSettings = new KeycloakSettings();
        configuration.GetSection("KeycloakSettings").Bind(instance: keycloakSettings);

        services.AddHttpClient<IKeycloakClient, KeycloakClient>();

        services.AddScoped<IMinIOClient, MinIOClient>();

        return services;
    }
}
