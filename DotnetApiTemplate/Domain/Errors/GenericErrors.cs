namespace Domain.Errors;

public class GenericErrors
{
    public static Error GenericError = new Error(message: "Error message", statusCode: 500);

    public static Error NotFoundError(string entityType, Guid id)
    {
        return new Error(message: $"No {entityType} with id={id} found.", statusCode: 404);
    }
}
