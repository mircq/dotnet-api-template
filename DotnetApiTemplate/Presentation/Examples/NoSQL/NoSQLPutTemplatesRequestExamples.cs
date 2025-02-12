using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLPutTemplatesRequestExamples
{
    public static List<OpenApiParameter> NoSQLPutTemplatesRequestParameterExamples()
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
    public static OpenApiRequestBody NoSQLPutTemplatesRequestExample()
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
                            { "description", new OpenApiString(value: "Sample template description") },
                            { "value", new OpenApiInteger(value: 4) }
                        }
                    }
                }
            }
        };
    }
}
