using Application.Clients.Broker;
using Application.Clients.Storage;
using Domain.Entities;
using Infrastructure.Clients;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Settings.Broker;
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

        #region Storage
        BrokerSettings brokerSettings = new();
        configuration.GetSection(key: "BrokerSettings").Bind(instance: brokerSettings);

        services.AddSingleton(brokerSettings);

        services.AddScoped<IBrokerClient<TemplateEntity>, BrokerClient<TemplateEntity>>();
        #endregion

        return services;
    }
}
