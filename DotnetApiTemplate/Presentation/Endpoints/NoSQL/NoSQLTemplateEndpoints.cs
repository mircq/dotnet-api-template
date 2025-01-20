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
using Presentation.Examples.NoSQL;
using Presentation.Mappers.Generic;
using Presentation.Mappers.NoSQL;
using Presentation.Examples.NoSQL;

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
        )
        .WithMetadata(new OpenApiOperation
         {
             Summary = "Retrieve a single template.",
             Description = "Retrieve the template with the given id.",
             Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },
             Responses = NoSQLGetTemplatesResponseExamples.NoSQLGetTemplatesResponseExample(),
             Parameters = NoSQLGetTemplatesRequestExamples.NoSQLGetTemplatesRequestParameterExamples()

         });


        app.MapGet(
            pattern: "/nosql/templates",
            handler: async (
                [FromServices] NoSQLTemplateGetMapper mapper,
                [FromServices] INoSQLTemplateService templateService
            ) =>
            {
                // TODO
                Result<TemplateEntity> result = await templateService.ListAsync();

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                NoSQLTemplateGetOutputDTO output = mapper.ToDTO(entity: result.Value);

                return Results.Ok(value: result.Value);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Retrieve a list of templates.",
            Description = "Retrieve the templates that match the given conditions.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },       
            Responses = NoSQLListTemplatesResponseExamples.NoSQLListTemplatesResponseExample(),
        });


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
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Create a template.",
            Description = "Create a new template.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },
            Responses = NoSQLPostTemplatesResponseExamples.NoSQLPostTemplatesResponseExample(),
            RequestBody = NoSQLPostTemplatesRequestExamples.NoSQLPostTemplatesRequestExample()
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
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Replace a template.",
            Description = "Replace the template with the given id with the one passed in the request body.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },
            Responses = NoSQLPutTemplatesResponseExamples.NoSQLPutTemplatesResponseExample(),
            Parameters = NoSQLPutTemplatesRequestExamples.NoSQLPutTemplatesRequestParameterExamples(),
            RequestBody = NoSQLPutTemplatesRequestExamples.NoSQLPutTemplatesRequestExample()
        });
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
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Delete a template.",
            Description = "Delete the template with the given id.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },
            Parameters = NoSQLDeleteTemplatesRequestExamples.NoSQLDeleteTemplatesRequestParameterExamples(),
            Responses = NoSQLDeleteTemplatesResponseExamples.NoSQLDeleteTemplatesResponseExample(),
        });
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
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Patch a template.",
            Description = "Apply the given patches to the template with the given id.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "NoSQL" } },
            Parameters = NoSQLPatchTemplatesRequestExamples.NoSQLPatchTemplatesRequestParameterExamples(),
            Responses = NoSQLPatchTemplatesResponseExamples.NoSQLPatchTemplatesResponseExample(),
            RequestBody = NoSQLPatchTemplatesRequestExamples.NoSQLPatchTemplatesRequestExample()
        });
        #endregion
    }
}
