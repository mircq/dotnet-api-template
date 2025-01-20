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
                            { "id", new OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb") },
                            { "description", new OpenApiString("Sample template description") }
                        }
                    }
                }
            }
        };
    }
}
