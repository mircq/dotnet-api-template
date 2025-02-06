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
                            { "SortField", new OpenApiString("Description") },
                            { "SortOrder", new OpenApiString("asc") },
                            { "PageNumber", new OpenApiInteger(1) },
                            { "PageSize", new OpenApiInteger(10) },
                            { "Filters", new OpenApiArray
                                {
                                    new OpenApiObject{
                                        { "Key", new OpenApiString("description")},
                                        { "Value", new OpenApiString("Sample description")},
                                        { "Operator",  new OpenApiString("==")},
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
