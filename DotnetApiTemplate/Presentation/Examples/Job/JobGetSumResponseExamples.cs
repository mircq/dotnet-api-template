using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.Job;

public class JobGetSumResponseExamples
{
    public static OpenApiResponses JobGetTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "200", new OpenApiResponse
                {
                    Description = "Task result retrieved successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["value"] = new OpenApiInteger(value: 6)
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
                                Example = new OpenApiObject
                                {
                                    ["error"] = new OpenApiString("Task not found")
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
                                    ["message"] = new OpenApiString(value: "An error occurred while retrieving the task.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
