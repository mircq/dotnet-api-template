using Application.Interfaces.Job;
using Application.Interfaces.MinIO;
using Carter;
using Domain.Entities;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Job;
using Presentation.DTOs.MinIO;
using Presentation.DTOs.NoSQL;
using Presentation.Examples.MinIO;
using Presentation.Mappers.Job;
using Presentation.Mappers.NoSQL;

namespace Presentation.Endpoints.Job;

public class JobTemplatesEndpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get
        #endregion

        #region Post
        app.MapPost(
            pattern: "/job/templates",
            handler: async (
                IFormFile file,
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
            Summary = "Upload a file in MinIO.",
            Description = "Upload a file into a MinIO bucket.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "MinIO" } },
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
