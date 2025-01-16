using System;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs;
using Presentation.Mappers;
using Application.Interfaces;
using Presentation.DTOs.Generic;

namespace Presentation.Endpoints;

public class TemplateEndpoints : ICarterModule
{

    public TemplateEndpoints() : base("/sql") { }

    public void AddRoutes(IEndpointRouteBuilder app)
    {   
        #region Get

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

        #region Put

        app.MapPut(
            pattern: "/template/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] TemplatePutInputDTO body,
                [FromServices] TemplatePutMapper mapper,
                [FromServices] ITemplateService templateService
            ) => {

                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PutAsync(id: id, entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                TemplatePutOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            });
        #endregion

        #region Delete

        app.MapDelete(
            pattern: "/template/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromServices] TemplateDeleteMapper mapper,
                [FromServices] ITemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.DeleteAsync(id: id);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                TemplateDeleteOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            });
        #endregion

        #region Patch

        app.MapPut(
            pattern: "/template/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] PatchDTO body,
                [FromServices] TemplatePatchMapper mapper,
                [FromServices] ITemplateService templateService
            ) => {

                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PatchAsync(id: id, patches: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                TemplatePatchOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            });
        #endregion
    }
}
