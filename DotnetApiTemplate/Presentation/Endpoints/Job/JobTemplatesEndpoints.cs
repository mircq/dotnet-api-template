using Application.Interfaces.Job;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Job;
using Presentation.Mappers.Job;

namespace Presentation.Endpoints.Job;

public class JobTemplatesEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get
        app.MapGet(
            pattern: "/job/templates/{id}",
            handler: async (
                [FromBody] JobInputDTO body,
                [FromServices] JobTemplateMapper templateMapper,
                [FromServices] JobGenericMapper genericMapper,
                [FromServices] IJobService<TemplateEntity> jobService
            ) =>
            {

                JobEntity entity = genericMapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await jobService.EnqueueAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                JobTemplateOutputDTO output = templateMapper.ToDTO(entity: result.Value);

                return Results.Ok<JobTemplateOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Enqueue a new job.",
            Description = "Put a new job into the queue.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Jobs" } },
            // Responses = NoSQLGetTemplatesResponseExamples.NoSQLGetTemplatesResponseExample(),
            //Parameters = NoSQLGetTemplatesRequestExamples.NoSQLGetTemplatesRequestParameterExamples()

        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/job/templates",
            handler: async (
                [FromBody] JobInputDTO body,
                [FromServices] JobTemplateMapper templateMapper,
                [FromServices] JobGenericMapper genericMapper,
                [FromServices] IJobService<TemplateEntity> jobService
            ) =>
            {

                JobEntity entity = genericMapper.ToEntity(dto: body);

                Result<TemplateEntity> result = await jobService.EnqueueAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                JobTemplateOutputDTO output = templateMapper.ToDTO(entity: result.Value);

                return Results.Ok<JobTemplateOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Enqueue a new job.",
            Description = "Put a new job into the queue.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Jobs" } },
            // Responses = NoSQLGetTemplatesResponseExamples.NoSQLGetTemplatesResponseExample(),
            //Parameters = NoSQLGetTemplatesRequestExamples.NoSQLGetTemplatesRequestParameterExamples()

        });
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion

        #region Patch
        #endregion
    }
}
