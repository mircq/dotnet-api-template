using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.NoSQL;

public class NoSQLGetTemplatesRequestExamples
{
    public static List<OpenApiParameter> NoSQLGetTemplatesRequestParameterExamples()
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
}
