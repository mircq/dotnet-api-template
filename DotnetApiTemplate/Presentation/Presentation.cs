using Carter;
using Presentation.Extensions;
using Presentation.Mappers.Generic;
using Presentation.Mappers.NoSQL;
using Presentation.Mappers.SQL;

namespace Presentation;

public static class Presentation
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddCarter();
        services.AddSwaggerDocumentation();

        #region Mappers

        services.AddSingleton<SQLTemplateDeleteMapper>();
        services.AddSingleton<SQLTemplateGetMapper>();
        services.AddSingleton<SQLTemplatePatchMapper>();
        services.AddSingleton<SQLTemplatePostMapper>();
        services.AddSingleton<SQLTemplatePutMapper>();
        services.AddSingleton<SQLTemplateListMapper>();

        services.AddSingleton<NoSQLTemplateDeleteMapper>();
        services.AddSingleton<NoSQLTemplateGetMapper>();
        services.AddSingleton<NoSQLTemplatePatchMapper>();
        services.AddSingleton<NoSQLTemplatePostMapper>();
        services.AddSingleton<NoSQLTemplatePutMapper>();
        
        services.AddSingleton<ConditionMapper>();
        services.AddSingleton<FilterMapper>();
        services.AddSingleton<PatchMapper>();
        #endregion

        return services;
    }

    public static WebApplication UsePresentation(this WebApplication app)
    {
        app.MapCarter();
        app.UseSwaggerDocumentation();
        //app.UseRouting();
        //app.UseAuthorization();
        //app.MapControllers(); // If using MVC
        
        return app;
    }
}
