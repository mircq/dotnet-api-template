
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

namespace Presentation.Endpoints.Job;

public class JobGenericEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
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

                JobPostOutputDTO output = new(){ Id = result.Value}; 

                return Results.Accepted<JobPostOutputDTO>(value: output);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Enqueue a new job.",
            Description = "Put a new job into the queue.",
            Tags = [new OpenApiTag { Name = "Jobs" }],
            Responses = JobPostSumResponseExamples.JobPostSumResponseExample(),
            RequestBody = JobPostSumRequestExamples.JobPostSumRequestBodyExample()
        });
        #endregion
    }
}


