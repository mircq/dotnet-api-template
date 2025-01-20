using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;
namespace Presentation.Examples.NoSQL;

public class NoSQLListTemplatesResponseExamples
{
    public static OpenApiResponses NoSQLListTemplatesResponseExample()
    {
        return new OpenApiResponses
        {
            {
                "201", new OpenApiResponse
                {
                    Description = "Template retrieved successfully.",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Example = new OpenApiArray
                                {
                                    new OpenApiObject
                                    {
                                        ["id"] = new OpenApiString("a971277f-075f-454d-af58-a4c570fb2abb"),
                                        ["description"] = new OpenApiString("Sample template description"),
                                    },
                                    new OpenApiObject
                                    {
                                        ["id"] = new OpenApiString("b971277f-075f-454d-af58-a4c570fb2acc"),
                                        ["description"] = new OpenApiString("Sample template description"),
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
