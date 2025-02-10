using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.Storage;

public class StorageDeleteResponseExamples
{
    public static OpenApiResponses StorageDeleteResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "204", new OpenApiResponse
                {
                    Description = "File deleted successfully.",
                    
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
                                    ["message"] = new OpenApiString(value: "An error occurred while deleting the file.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
