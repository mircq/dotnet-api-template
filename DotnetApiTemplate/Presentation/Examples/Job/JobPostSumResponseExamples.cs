using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace Presentation.Examples.Job;

public class JobPostSumResponseExamples
{
    public static OpenApiResponses JobPostSumResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "202", new OpenApiResponse
                {
                    Description = "Job enqueued successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["id"] = new OpenApiString(value: "a971277f-075f-454d-af58-a4c570fb2abb"),                 
                                }
                            }
                        }
                    }
                }
            },
            {
                "500", new OpenApiResponse
                {
                    Description = "Internal server error",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiObject
                                {
                                    ["message"] = new OpenApiString(value: "An error occurred while deleting the template.")
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
