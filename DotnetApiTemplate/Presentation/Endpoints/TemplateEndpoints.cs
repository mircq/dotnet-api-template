using System;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;
using Presentation.Mappers;
using Application.Interfaces;

namespace Presentation.Endpoints;

public class TemplateEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {   
        #region Get
        app.MapGet("/template", () => "Hello frommm Carter!");

        app.MapGet(
            pattern: "/template/{id}", 
            handler: async (
                [FromRoute] Guid id,
                [FromServices] TemplateGetMapper mapper,
                [FromServices] ITemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.GetAsync(id: id);
                
                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }
                
                TemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/template", 
            handler: async(
                [FromBody] TemplatePostInputDTO body,
                [FromServices] TemplatePostMapper mapper,
                [FromServices] ITemplateService templateService
            ) => 
            {
                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PostAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                TemplatePostOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Created(uri: output.Id.ToString(), value: output);
            }
        );
        #endregion
    }
}
