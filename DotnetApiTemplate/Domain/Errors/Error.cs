using System;

namespace Domain.Errors;

public class Error
{
    public readonly string Message;
    public readonly int StatusCode;

    public Error(string message, int statusCode = 500)
    {
        Message = message;
        StatusCode = statusCode;
    }
}
