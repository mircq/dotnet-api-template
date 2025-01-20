﻿using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLDeleteTemplatesResponseExamples
{
    public static OpenApiResponses NoSQLDeleteTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "201", new OpenApiResponse
                {
                    Description = "Template deleted successfully.",
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
