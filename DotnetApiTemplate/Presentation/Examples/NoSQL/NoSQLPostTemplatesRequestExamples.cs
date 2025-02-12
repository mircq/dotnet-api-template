using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLPostTemplatesRequestExamples
{
    public static OpenApiRequestBody NoSQLPostTemplatesRequestExample()
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
