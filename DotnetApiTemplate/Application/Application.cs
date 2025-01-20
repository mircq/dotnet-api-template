using Application.Interfaces.NoSQL;
using Application.Interfaces.SQL;
using Application.Services.NoSQL;
using Application.Services.SQL;

namespace Application;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services registration

        services.AddScoped<ISQLTemplateService, SQLTemplateService>();
        services.AddScoped<INoSQLTemplateService, NoSQLTemplateService>();

        return services;
    }
}
