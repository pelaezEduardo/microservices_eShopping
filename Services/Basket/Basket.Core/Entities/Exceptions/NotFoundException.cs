namespace Basket.Core.Entities.Exceptions;

public abstract class NotFoundException: Exception
{
    protected NotFoundException(string message) : base(message) {}
}