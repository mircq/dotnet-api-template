using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLPutTemplatesRequestExamples
{
    public static List<OpenApiParameter> SQLPutTemplatesRequestParameterExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "id",
                In = ParameterLocation.Path,
                Required = true,
                Description = "The unique ID of the template.",
                Example = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb")
            }
        };
    }
    public static OpenApiRequestBody SQLPutTemplatesRequestExample()
    {
        return new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json", new OpenApiMediaType
                    {
                        Example = new OpenApiObject
                        {
                            { "description", new OpenApiString("Sample template description") },
                            { "value", new OpenApiInteger(value: 4) }
                        }
                    }
                }
            }
        };
    }
}
