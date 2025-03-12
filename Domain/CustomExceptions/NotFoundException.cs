namespace Domain.CustomExceptions;

public class NotFoundException : Exception
{
    public readonly int StatusCode;

    public NotFoundException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public NotFoundException(string message) : base(message)
    {
    }
}