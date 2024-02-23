namespace MadWorldNL.Common.Exceptions;

public class ValidationException : Exception
{
    public string ErrorCode { get; private set;  }

    public ValidationException(string errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}