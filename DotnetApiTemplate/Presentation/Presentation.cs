using Carter;
using Presentation.Mappers.NoSQL;
using Presentation.Mappers.SQL;

namespace Presentation;

public static class Presentation
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        Console.WriteLine("Initializng presentation layer");

        services.AddCarter();

        // Mappers registration

        services.AddSingleton<SQLTemplateDeleteMapper>();
        services.AddSingleton<SQLTemplateGetMapper>();
        services.AddSingleton<SQLTemplatePatchMapper>();
        services.AddSingleton<SQLTemplatePostMapper>();
        services.AddSingleton<SQLTemplatePutMapper>();

        services.AddSingleton<NoSQLTemplateDeleteMapper>();
        services.AddSingleton<NoSQLTemplateGetMapper>();
        services.AddSingleton<NoSQLTemplatePatchMapper>();
        services.AddSingleton<NoSQLTemplatePostMapper>();
        services.AddSingleton<NoSQLTemplatePutMapper>();

        return services;
    }
}
