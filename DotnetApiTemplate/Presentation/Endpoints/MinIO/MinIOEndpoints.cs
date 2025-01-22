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
using Presentation.Examples.NoSQL;


namespace Presentation.Endpoints;

public class MinIOEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        #region Get

        app.MapGet(
            pattern: "/minio/{name}",
            handler: async (
                [FromRoute] string name,
                [FromServices] IMinIOService minioService
            ) => {

                Result<Stream> result = await minioService.GetAsync(path: name);

                if (result.IsFailure)
                {
                    return Results.Json(data: result.Error.Message, statusCode: result.Error.StatusCode);
                }

                return Results.Stream(result.Value);
               

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


       

        #endregion

        #region Post
        #endregion

        #region Put
        #endregion

        #region Delete
        #endregion

        #region Patch
        #endregion
    }
}
