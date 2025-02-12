using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.NoSQL;

public class NoSQLListTemplatesResponseExamples
{
    public static OpenApiResponses NoSQLListTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "200", new OpenApiResponse
                {
                    Description = "Templates retrieved successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiArray
                                {
                                    new OpenApiObject
                                    {
                                        ["id"] = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb"),
                                        ["description"] = new OpenApiString(value: "Sample template description"),
                                        ["value"] = new OpenApiInteger(value: 4),
                                    },
                                    new OpenApiObject
                                    {
                                        ["id"] = new OpenApiString(value: "b971277f-075f-454d-af58-a4c570fb2acc"),
                                        ["description"] = new OpenApiString(value: "Sample template description"),
                                        ["value"] = new OpenApiInteger(value: 4),
                                    }
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
                                    ["message"] = new OpenApiString(value: "An error occurred while retrieveing templates.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
