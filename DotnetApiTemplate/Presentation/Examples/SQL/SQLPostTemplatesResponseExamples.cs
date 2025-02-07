using Microsoft.OpenApi.Any;
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
                                Example = new OpenApiObject
                                {
                                    ["id"] = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb"),
                                    ["description"] = new OpenApiString(value: "Sample template description"),
                                    ["value"] = new OpenApiInteger(value: 4),
                                }
                            }
                        }
                    }
                }
            },
            {
                "500", new OpenApiResponse
                {
                    Description = "Internal server error",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["message"] = new OpenApiString(value: "An error occurred while creating the template.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
