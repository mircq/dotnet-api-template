﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLPatchTemplatesRequestExamples
{
    public static List<OpenApiParameter> SQLPatchTemplatesRequestParameterExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "id",
                In = ParameterLocation.Path,
                Required = true,
                Description = "The unique ID of the template.",
                Example = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb")
            }
        };
    }

    public static OpenApiRequestBody SQLPatchTemplatesRequestExample()
    {
        return new OpenApiRequestBody
        {
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json", new OpenApiMediaType
                    {
                        Example = new OpenApiArray
                        {
                            new OpenApiObject
                            {
                                { "op", new OpenApiString(value: "replace") },
                                { "path", new OpenApiString(value: "/description") },
                                { "value", new OpenApiString(value: "Sample template description") }
                            }
                        }
                    }
                }
            }
        };
    }
}
