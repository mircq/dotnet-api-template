using Application.Interfaces.Job;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Job;
using Presentation.Examples.Job;
using Presentation.Mappers.Job;

namespace Presentation.Endpoints.Job;

public class JobTemplatesEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get
        app.MapGet(
            pattern: "/jobs/sum/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromQuery] bool wait,
                [FromServices] JobTemplateMapper templateMapper,
                [FromServices] JobGenericMapper genericMapper,
                [FromServices] IJobService<SumEntity> jobService
            ) =>
            {

                Result<SumEntity> result = await jobService.GetAsync(id: id, wait: wait);

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
            Summary = "Get a job's result.",
            Description = "Put a new job into the queue.",
            Tags = [new() { Name = "Jobs" }],
            //Responses = NoSQLGetTemplatesResponseExamples.NoSQLGetTemplatesResponseExample(),
            //Parameters = NoSQLGetTemplatesRequestExamples.NoSQLGetTemplatesRequestParameterExamples()

        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/jobs/sum",
            handler: async (
                [FromBody] JobInputDTO body,
                [FromServices] JobTemplateMapper templateMapper,
                [FromServices] JobGenericMapper genericMapper,
                [FromServices] IJobService<TemplateEntity> jobService
            ) =>
            {

                JobEntity entity = genericMapper.ToEntity(dto: body);

                Result<Guid> result = await jobService.EnqueueAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                JobPostTemplateOutputDTO output = new(){ Id = result.Value}; 

                return Results.Ok<JobPostTemplateOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Enqueue a new job.",
            Description = "Put a new job into the queue.",
            Tags = [new OpenApiTag { Name = "Jobs" }],
            Responses = JobPostTemplatesResponseExamples.JobPostTemplatesResponseExample(),
            RequestBody = JobPostTemplatesRequestExamples.JobPostTemplatesRequestBodyExamples()

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
