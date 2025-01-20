using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLPatchTemplatesRequestExamples
{
    public static List<OpenApiParameter> NoSQLPatchTemplatesRequestParameterExamples()
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

    public static OpenApiRequestBody NoSQLPatchTemplatesRequestExample()
    {
        return new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json", new OpenApiMediaType
                    {
                        Example = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                { "op", new OpenApiString("replace") },
                                { "path", new OpenApiString("/description") },
                                { "value", new OpenApiString("Sample template description") }
                            }
                        }
                    }
                }
            }
        };
    }
}
