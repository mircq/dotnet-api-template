using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLPostTemplatesRequestExamples
{
    public static OpenApiRequestBody SQLPostTemplatesRequestExample()
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
                            { "description", new OpenApiString(value: "Sample template description") },
                            { "value", new OpenApiInteger(value: 4)}
                        }
                    }
                }
            }
        };
    }
}
