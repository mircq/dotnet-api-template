using Application.Interfaces.NoSQL;
using Carter;
using Carter.OpenApi;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Generic;
using Presentation.DTOs.NoSQL;
using Presentation.Mappers.Generic;
using Presentation.Mappers.NoSQL;

namespace Presentation.Endpoints;

public class NoSQLTemplateEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get

        app.MapGet(
            pattern: "/nosql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromServices] NoSQLTemplateGetMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.GetAsync(id: id);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Retrieve a single template.")
        .WithDescription(description: "Retrieve the template with the given id.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 200)
         .WithMetadata(new OpenApiOperation
         {
             Summary = "Update an existing car",
             Description = "Updates the car details.",
             RequestBody = new OpenApiRequestBody
             {
                 Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json", new OpenApiMediaType
                    {
                        Example = new OpenApiObject
                        {
                            { "id", new OpenApiInteger(1) },
                            { "make", new OpenApiString("Toyota") },
                            { "model", new OpenApiString("Camry") }
                        }
                    }
                }
            }
             },
        //     Responses = new Dictionary<string, OpenApiResponse>
        //{
        //    { "200", new OpenApiResponse
        //        {
        //            Description = "Updated",
        //            Content = new Dictionary<string, OpenApiMediaType>
        //            {
        //                {
        //                    "application/json", new OpenApiMediaType
        //                    {
        //                        Example = new OpenApiObject
        //                        {
        //                            { "id", new OpenApiInteger(1) },
        //                            { "make", new OpenApiString("Toyota") },
        //                            { "model", new OpenApiString("Camry") }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    },
        //    { "204", new OpenApiResponse { Description = "No Content" } }
        //}
         });


        app.MapGet(
            pattern: "/nosql/templates",
            handler: async (
                [FromServices] NoSQLTemplateGetMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.ListAsync();

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Retrieve a list of templates.")
        .WithDescription(description: "Retrieve the templates that match the given conditions.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 200);


        #endregion

        #region Post
        app.MapPost(
            pattern: "/nosql/templates",
            handler: async (
                [FromBody] NoSQLTemplatePostInputDTO body,
                [FromServices] NoSQLTemplatePostMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) =>
            {
                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PostAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplatePostOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Created(uri: output.Id.ToString(), value: output);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Create a template")
        .WithDescription(description: "Create a new template.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 201)
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Update an existing car",
            Description = "Updates the car details.",
            RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    {
                        "application/json", new OpenApiMediaType
                        {
                            Example = new OpenApiObject
                            {
                                { "id", new OpenApiInteger(1) },
                                { "make", new OpenApiString("Toyota") },
                                { "model", new OpenApiString("Camry") }
                            }
                        }
                    }
                }
            }
        });
        #endregion

        #region Put

        app.MapPut(
            pattern: "/nosql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] NoSQLTemplatePutInputDTO body,
                [FromServices] NoSQLTemplatePutMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) =>
            {

                TemplateEntity entity = mapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await templateService.PutAsync(id: id, entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplatePutOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Replace a template")
        .WithDescription(description: "Replace the template with the given id with the one passed in the request body.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 200);
        #endregion

        #region Delete

        app.MapDelete(
            pattern: "/nosql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromServices] NoSQLTemplateDeleteMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) => {

                Result<TemplateEntity> result = await templateService.DeleteAsync(id: id);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplateDeleteOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Delete a template")
        .WithDescription(description: "Delete the template with the given id.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 200);
        #endregion

        #region Patch

        app.MapPatch(
            pattern: "/nosql/templates/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromBody] PatchDTO body,
                [FromServices] NoSQLTemplatePatchMapper mapper,
                [FromServices] PatchMapper patchMapper,
                [FromServices] INoSQLTemplateService templateService
            ) => {

                // TODO considered one patch only
                List<PatchEntity> entity = [patchMapper.ToEntity(dto: body)];

                Result<TemplateEntity> result = await templateService.PatchAsync(id: id, patches: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplatePatchOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        ).WithTags(tags: ["NoSQL"])
        .WithSummary(summary: "Patch a template.")
        .WithDescription(description: "Apply the given patches to the template with the given id.")
        .Produces<NoSQLTemplateGetOutputDTO>(statusCode: 200);
        #endregion
    }
}
