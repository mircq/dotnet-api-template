using Application.Interfaces.Job;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Generic;
using Presentation.DTOs.Job;
using Presentation.Examples.Job;
using Presentation.Mappers.Generic;
using Presentation.Mappers.Job;

namespace Presentation.Endpoints.Job;

public class JobSumEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get
        app.MapGet(
            pattern: "/jobs/sum/{id}",
            handler: async (
                [FromRoute] Guid id,
                [FromQuery] bool wait,
                [FromServices] JobSumMapper sumMapper,
                [FromServices] JobMapper genericMapper,
                [FromServices] IJobService<SumEntity> jobService
            ) =>
            {

                Result<SumEntity> result = await jobService.GetAsync(id: id, wait: wait);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                JobGetSumOutputDTO output = sumMapper.ToDTO(entity: result.Value);

                return Results.Ok<JobGetSumOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Get a job's result.",
            Description = "Retrieve the result of the job with the given id.",
            Tags = [new() { Name = "Jobs" }],
            Responses = JobGetSumResponseExamples.JobGetTemplatesResponseExample(),
            Parameters = JobGetSumRequestExamples.JobGetSumRequestParameterExamples()

        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/jobs",
            handler: async (
                [FromBody] JobDTO body,
                [FromServices] JobMapper mapper,
                // TODO should be void not SumEntity
                [FromServices] IJobService<SumEntity> jobService
            ) =>
            {

                JobEntity entity = mapper.ToEntity(dto: body);

                Result<Guid> result = await jobService.EnqueueAsync(entity: entity);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                JobPostSumOutputDTO output = new(){ Id = result.Value}; 

                return Results.Ok<JobPostSumOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Enqueue a new sum job.",
            Description = "Put a new sum job into the queue.",
            Tags = [new OpenApiTag { Name = "Jobs" }],
            Responses = JobPostSumResponseExamples.JobPostSumResponseExample(),
            RequestBody = JobPostSumRequestExamples.JobPostSumRequestBodyExample()

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
