using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLGetTemplatesResponseExamples
{
    public static OpenApiResponses SQLGetTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "201", new OpenApiResponse
                {
                    Description = "Template retrieved successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new Microsoft.OpenApi.Any.OpenApiObject
                                {
                                    ["Id"] = new Microsoft.OpenApi.Any.OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb"),
                                    ["Description"] = new Microsoft.OpenApi.Any.OpenApiString("Sample template description"),
                                }
                            }
                        }
                    }
                }
            },
            {
                "404", new OpenApiResponse
                {
                    Description = "Not Found",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new Microsoft.OpenApi.Any.OpenApiObject
                                {
                                    ["error"] = new Microsoft.OpenApi.Any.OpenApiString("Template not found")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
