﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLPatchTemplatesResponseExamples
{
    public static OpenApiResponses SQLPatchTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "200", new OpenApiResponse
                {
                    Description = "Template patched successfully.",
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
                                    ["message"] = new OpenApiString("Template with id={} not found")
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
                                    ["message"] = new OpenApiString(value: "An error occurred while patching the template.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
