using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.Job;

public class JobGetSumRequestExamples
{
    public static List<OpenApiParameter> JobGetSumRequestParameterExamples()
    {
        return
        [
            new() {
                Name = "id",
                In = ParameterLocation.Path,
                Required = true,
                Description = "The unique ID of the job.",
                Example = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb")
            },
            new OpenApiParameter
            {
                Name = "wait",
                In = ParameterLocation.Query,
                Required = true,
                Description = "Whether to wait task completion or not.",
                Example = new OpenApiBoolean(value: true)
            }
        ];
    }
}
