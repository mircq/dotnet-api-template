using System;
using Domain.Errors;

namespace Infrastructure.Errors;

public class TemplateErrors
{
    public static Error GenericError = new Error(message: "Error message", statusCode: 500);

    public static Error NotFoundError = new Error(message: "No template with id={} found.", statusCode: 404);
}