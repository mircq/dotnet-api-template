using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLListTemplatesRequestExamples
{
    public static OpenApiRequestBody SQLListTemplatesRequestBodyExamples()
    {
        return new OpenApiRequestBody
        {
            
            Content = new Dictionary<string, OpenApiMediaType>
            {
                {
                    "application/json", new OpenApiMediaType
                    {
                        Example = new OpenApiObject
                        {
                            { "SortField", new OpenApiString(value: "Description") },
                            { "SortOrder", new OpenApiString(value: "asc") },
                            { "PageNumber", new OpenApiInteger(value: 1) },
                            { "PageSize", new OpenApiInteger(value: 10) },
                            { "Filters", new OpenApiArray
                                {
                                    new OpenApiObject{
                                        { "Key", new OpenApiString(value: "value")},
                                        { "Value", new OpenApiInteger(value: 4)},
                                        { "Operator",  new OpenApiString(value: "==")},
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
