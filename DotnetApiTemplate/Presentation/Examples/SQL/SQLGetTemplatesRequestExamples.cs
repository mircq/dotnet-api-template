using Microsoft.OpenApi.Models;

namespace Presentation.Examples.SQL;

public class SQLGetTemplatesRequestExamples
{
    public static List<OpenApiParameter> SQLGetTemplatesRequestParameterExamples()
    {
        return new List<OpenApiParameter>
        {
            new OpenApiParameter
            {
                Name = "id",
                In = ParameterLocation.Path,
                Required = true,
                Description = "The unique ID of the template.",
                Example = new Microsoft.OpenApi.Any.OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb") 
            }
        };
    }
}
