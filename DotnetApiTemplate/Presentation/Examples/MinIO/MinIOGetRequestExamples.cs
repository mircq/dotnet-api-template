using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.MinIO;

public class MinIOGetRequestExamples
{
    public static List<OpenApiParameter> MinIOGetRequestQueryExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "id",
                In = ParameterLocation.Query,
                Required = true,
                Description = "Path of the file to download.",
                Example = new OpenApiString("folder/text.txt")
            }
        };
    }
}
