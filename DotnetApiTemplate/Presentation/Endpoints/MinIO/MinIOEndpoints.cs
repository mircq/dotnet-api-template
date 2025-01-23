using System.IO;
using System.Net;
using Application.Interfaces.MinIO;
using Carter;
using Domain.Entities;
using Domain.Result;
using Infrastructure.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Presentation.DTOs.MinIO;
using Presentation.Examples.MinIO;


namespace Presentation.Endpoints;

public class MinIOEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get

        app.MapGet(
            pattern: "/minio",
            handler: async (
                [FromQuery] string path,
                [FromServices] IMinIOService minioService
            ) => {

                Result<Stream> result = await minioService.GetAsync(path: path);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.Stream(result.Value);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Download a file from MinIO.",
            Description = "Download a file from a MinIO bucket.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "MinIO" } },
            Parameters = MinIOGetRequestExamples.MinIOGetRequestQueryExamples()

        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/minio",
            handler: async (
                IFormFile file,
                [FromBody] MinIOPostInputDTO dto,
                [FromServices] IMinIOService minioService
            ) =>
            {

                if (file == null || file.Length == 0)
                {
                    return Results.BadRequest(error: "No file or empty file provided.");
                }

                // Upload the file to MinIO
                using Stream fileStream = file.OpenReadStream();
                Result<string> result = await minioService.PostAsync(path: $"{dto.BasePath}/{dto.Filename}", stream: fileStream);
                //Result<Stream> result = await minioService.PostAsync(bucketName, objectName, fileStream, contentType);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.Created<string>(uri: result.Value, value: null);
            }
        )
        .WithSummary(summary: "Upload a file in MinIO.")
        .WithDescription(description: "Upload a file into a MinIO bucket.")
        .WithTags(tags: ["MinIO"])
        .DisableAntiforgery();
        //.WithMetadata(new OpenApiOperation
        //{
        //    Summary = "Upload a file in MinIO.",
        //    Description = "Upload a file into a MinIO bucket.",
        //    Tags = new List<OpenApiTag> { new OpenApiTag { Name = "MinIO" } },
        //    // Responses = NoSQLGetTemplatesResponseExamples.NoSQLGetTemplatesResponseExample(),
        //    //Parameters = NoSQLGetTemplatesRequestExamples.NoSQLGetTemplatesRequestParameterExamples()

        //});
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion

        #region Patch
        #endregion
    }
}
