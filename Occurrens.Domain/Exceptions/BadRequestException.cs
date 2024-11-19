using Occurrens.Domain.Abstracts;

namespace Occurrens.Domain.Exceptions;

public class BadRequestException : BaseException
{
    public string ErrorMessage { get; }
    
    public BadRequestException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}