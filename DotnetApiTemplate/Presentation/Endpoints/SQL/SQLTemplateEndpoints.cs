using System;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Presentation.DTOs.SQL;
using Presentation.Mappers.SQL;
using Presentation.DTOs.Generic;
using Presentation.Mappers.Generic;
using Application.Interfaces.SQL;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Endpoints;

public class SQLTemplateEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get

        app.MapGet(
            pattern: "/sql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromServices] SQLTemplateGetMapper mapper,
                [FromServices] ISQLTemplateService templateService
            ) =>
            {

                Result<TemplateEntity> result = await templateService.GetAsync(id: id);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Retrieve a single template.")
        .WithDescription(description: "Retrieve the template with the given id.")
        .Produces<SQLTemplateGetOutputDTO>(statusCode: 200);
        
        app.MapGet(
            pattern: "/sql/templates",
            handler: async (
                [FromServices] SQLTemplateGetMapper mapper,
                [FromServices] ISQLTemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.ListAsync();

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Retrieve a list of templates.")
        .WithDescription(description: "Retrieve the templates that match the given conditions.")
        .Produces<SQLTemplateGetOutputDTO>(statusCode: 200);


        #endregion

        #region Post
        app.MapPost(
            pattern: "/sql/templates", 
            handler: async(
                [FromBody] SQLTemplatePostInputDTO body,
                [FromServices] SQLTemplatePostMapper mapper,
                [FromServices] ISQLTemplateService templateService
            ) => 
            {
                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PostAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplatePostOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Created(uri: output.Id.ToString(), value: output);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Create a template")
        .WithDescription(description: "Create a new template.")
        .Produces<SQLTemplatePostOutputDTO>(statusCode: 201);
        #endregion

        #region Put

        app.MapPut(
            pattern: "/sql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] SQLTemplatePutInputDTO body,
                [FromServices] SQLTemplatePutMapper mapper,
                [FromServices] ISQLTemplateService templateService
            ) => {

                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PutAsync(id: id, entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplatePutOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Replace a template")
        .WithDescription(description: "Replace the template with the given id with the one passed in the request body.")
        .Produces<SQLTemplatePutOutputDTO>(statusCode: 200);
        
        #endregion

        #region Delete

        app.MapDelete(
            pattern: "/sql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromServices] SQLTemplateDeleteMapper mapper,
                [FromServices] ISQLTemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.DeleteAsync(id: id);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplateDeleteOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Delete a template")
        .WithDescription(description: "Delete the template with the given id.")
        .Produces<SQLTemplateDeleteOutputDTO>(statusCode: 200);
        #endregion

        #region Patch

        app.MapPatch(
            pattern: "/sql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] PatchDTO body,
                [FromServices] SQLTemplatePatchMapper mapper,
                [FromServices] PatchMapper patchMapper,
                [FromServices] ISQLTemplateService templateService
        ) =>
            {

                List<PatchEntity> patches = [patchMapper.ToEntity(dto: body)]; ;

                Result<TemplateEntity> result = await templateService.PatchAsync(id: id, patches: patches);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                SQLTemplatePatchOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["SQL"])
        .WithSummary(summary: "Patch a template.")
        .WithDescription(description: "Apply the given patches to the template with the given id.")
        .Produces<SQLTemplatePatchOutputDTO>(statusCode: 200);
        #endregion
    }
}
