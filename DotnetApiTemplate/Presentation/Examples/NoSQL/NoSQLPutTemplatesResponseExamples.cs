using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLPutTemplatesResponseExamples
{
    public static OpenApiResponses NoSQLPutTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "200", new OpenApiResponse
                {
                    Description = "Template replaced successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["description"] = new OpenApiString(value: "Sample template description"),
                                    ["value"] = new OpenApiInteger(value: 4),
                                }
                            }
                        }
                    }
                }
            },
            {
                "404", new OpenApiResponse
                {
                    Description = "Template not found",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["message"] = new OpenApiString(value: "Template not found")
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
                                    ["message"] = new OpenApiString(value: "An error occurred while replacing the template.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
