
using OneOf;

namespace Domain.Errors;


public class GenericErrors
{
    public static Error GenericError(string message)
    {
        return new Error(message: message, statusCode: 500);
    }

    public static Error NotFoundError(string entityType, OneOf<string, Guid> id)
    {
        return new Error(message: $"No {entityType} with id={id} found.", statusCode: 404);
    }
}
