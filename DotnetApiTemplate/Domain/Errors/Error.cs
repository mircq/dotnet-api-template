namespace Domain.Errors;

public class Error(string message, int statusCode = 500)
{
    public readonly string Message = message;
    public readonly int StatusCode = statusCode;
}
