using Domain.Abstracts;

namespace Domain.Exceptions;

public class NotFoundException : BaseException
{
    public string ErrorMessage { get; }
    
    public NotFoundException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}