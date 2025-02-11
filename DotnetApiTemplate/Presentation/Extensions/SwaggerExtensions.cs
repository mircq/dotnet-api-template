
﻿using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace Presentation.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        

        services.AddSwaggerGen( options =>
        {
            
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Dotnet Template API",
                Version = "v1",
                Description = "A simple template for API written in C#.",
                
            });

            options.SchemaFilter<EnumSchemaFilter>();

            options.AddSecurityDefinition(
                name: "JWT Token", 
                securityScheme: new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization,
                    Scheme = "Bearer"
                }
             );
        });

        return services;
    }

    public static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Dotnet Template API");
            c.RoutePrefix = string.Empty; 
        });
    }
}
