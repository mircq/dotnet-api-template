using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.Storage;

public class StoragePostResponseExamples
{
    public static OpenApiResponses StoragePostResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "201", new OpenApiResponse
                {
                    Description = "File downloaded successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["uri"] = new OpenApiString(value: "file.txt")
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
                                    ["error"] = new OpenApiString("File not found")
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
                                    ["message"] = new OpenApiString(value: "An error occurred while downloading the file.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
