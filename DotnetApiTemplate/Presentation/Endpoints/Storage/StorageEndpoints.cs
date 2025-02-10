using Application.Interfaces.Storage;
using Carter;
using Domain.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Presentation.DTOs.Storage;
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

                Result<FileEntity> result = await storageService.GetAsync(path: path);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.File(fileStream: result.Value.Stream, contentType: "application/octet-stream", fileDownloadName: result.Value.FileName);
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Download a file from MinIO.",
            Description = "Download a file from a MinIO bucket.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Storage" } },
            Parameters = StorageGetRequestExamples.StorageGetRequestQueryExamples(),
            Responses = StorageGetResponseExamples.StorageGetResponseExample()
        });
        #endregion

        #region Post
        app.MapPost(
            pattern: "/storage",
            handler: async (
                [FromForm] StoragePostInputDTO dto,
                [FromServices] IStorageService storageService
            ) =>
            {

                if (dto.File == null || dto.File.Length == 0)
                {
                    return Results.BadRequest(error: "No file or empty file provided.");
                }

                Result<FileEntity> result = await storageService.PostAsync(path: dto.Path, file: dto.File);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.Created(uri: result.Value.FileName, value: null);
            }
        )
        .WithMetadata(
            items: new OpenApiOperation
            {
                Summary = "Upload a file in MinIO.",
                Description = "Upload a file into a MinIO bucket.",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Storage" } },
            //     Parameters = MinIOGetRequestExamples.MinIOGetRequestQueryExamples()

            }
        )
        .DisableAntiforgery();
        #endregion

        #region Put
        #endregion

        #region Delete

        app.MapDelete(
            pattern: "/storage",
            handler: async (
                [FromQuery] string path,
                [FromServices] IStorageService storageService
            ) => {

                Result<FileEntity> result = await storageService.DeleteAsync(path: path);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.NoContent();
            }
        )
        .WithMetadata(new OpenApiOperation
        {
            Summary = "Delete a file from MinIO.",
            Description = "Delete a file from a MinIO bucket.",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Storage" } },
            Parameters = StorageDeleteRequestExamples.StorageDeleteRequestQueryExamples(),
            Responses = StorageDeleteResponseExamples.StorageDeleteResponseExample()
        });
        #endregion

        #region Patch
        #endregion
    }
}
