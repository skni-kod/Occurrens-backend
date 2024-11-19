namespace Occurrens.Domain.Abstracts;

public abstract class BaseException : Exception
{
    protected BaseException(string message) : base(message) { }
}