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
            Summary = "Get a sum job's result.",
            Description = "Retrieve the result of the sum job with the given id.",
            Tags = [new() { Name = "Jobs" }],
            Responses = JobGetSumResponseExamples.JobGetTemplatesResponseExample(),
            Parameters = JobGetSumRequestExamples.JobGetSumRequestParameterExamples()
        });
        #endregion
    }
}