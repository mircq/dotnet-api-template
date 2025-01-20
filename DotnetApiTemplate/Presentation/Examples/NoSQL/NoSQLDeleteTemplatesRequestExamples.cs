using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.NoSQL;

public class NoSQLDeleteTemplatesRequestExamples
{
    public static List<OpenApiParameter> NoSQLDeleteTemplatesRequestParameterExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "id",
                In = ParameterLocation.Path,
                Required = true,
                Description = "The unique ID of the template.",
                Example = new OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb")
            }
        };
    }
}
