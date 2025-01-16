using System;
using Domain.Errors;

namespace Infrastructure.Errors;

public class TemplateErrors
{
    public static Error GenericError = new Error(message: "Error message", statusCode: 500);
}