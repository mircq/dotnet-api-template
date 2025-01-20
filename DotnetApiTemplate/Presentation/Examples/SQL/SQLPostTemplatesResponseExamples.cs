using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLPostTemplatesResponseExamples
{
    public static OpenApiResponses SQLPostTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "201", new OpenApiResponse
                {
                    Description = "Template created successfully",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new Microsoft.OpenApi.Any.OpenApiObject
                                {
                                    ["id"] = new Microsoft.OpenApi.Any.OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb"),
                                    ["description"] = new Microsoft.OpenApi.Any.OpenApiString("Sample template description"),
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
