namespace AspNetServer.Data.Exceptions;

public class DateTimeFormatException : Exception
{
    public DateTimeFormatException()
    {
    }

    public DateTimeFormatException(string message)
        : base(message)
    {
    }

    public DateTimeFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}