using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.Job;

public class JobPostSumRequestExamples
{
    public static OpenApiRequestBody JobPostSumRequestBodyExample()
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
                            
                            { "FunctionName", new OpenApiString(value: "sum") },
                            { "Args", new OpenApiArray([]) },
                            { "Kwargs", new OpenApiObject
                                {
                                    {"a", new OpenApiInteger(value: 2) },
                                    {"b", new OpenApiInteger(value: 4) }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
