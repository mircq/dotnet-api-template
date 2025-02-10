using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.Storage;

public class StorageDeleteRequestExamples
{
    public static List<OpenApiParameter> StorageDeleteRequestQueryExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "path",
                In = ParameterLocation.Query,
                Required = true,
                Description = "Path of the file to delete.",
                Example = new OpenApiString(value: "file.txt")
            }
        };
    }
}
