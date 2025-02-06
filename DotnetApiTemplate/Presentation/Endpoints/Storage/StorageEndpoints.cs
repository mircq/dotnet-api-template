using Application.Interfaces.Storage;
using Carter;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.Examples.Storage;


namespace Presentation.Endpoints;

public class StorageEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get

        app.MapGet(
            pattern: "/storage",
            handler: async (
                [FromQuery] string path,
                [FromServices] IStorageService storageService
            ) => {

                Result<Stream> result = await storageService.GetAsync(path: path);

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
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Storage" } },
            Parameters = StorageGetRequestExamples.StorageGetRequestQueryExamples()

        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/storage",
            handler: async (
                IFormFile file,
                string filename,
                string basePath,
                [FromServices] IStorageService storageService
            ) =>
            {

                if (file == null || file.Length == 0)
                {
                    return Results.BadRequest(error: "No file or empty file provided.");
                }

                // Upload the file to MinIO
                using Stream fileStream = file.OpenReadStream();
                Result<string> result = await storageService.PostAsync(path: $"{basePath}/{filename}", stream: fileStream);
                //Result<Stream> result = await minioService.PostAsync(bucketName, objectName, fileStream, contentType);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.Created<string>(uri: result.Value, value: null);
            }
        )
        // .WithMetadata(new OpenApiOperation
        // {
        //     Summary = "Upload a file in MinIO.",
        //     Description = "Upload a file into a MinIO bucket.",
        //     Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Storage" } },
        //     Parameters = MinIOGetRequestExamples.MinIOGetRequestQueryExamples()

        // });
        .WithSummary(summary: "Upload a file in MinIO.")
        .WithDescription(description: "Upload a file into a MinIO bucket.")
        .WithTags(tags: ["Storage"])
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
