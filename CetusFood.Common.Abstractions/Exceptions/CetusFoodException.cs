namespace CetusFood.Common.Abstractions.Exceptions;

public abstract class CetusFoodException : Exception
{
    protected CetusFoodException(string message) : base(message) { }
}

public abstract class BadRequestException : CetusFoodException
{
    protected BadRequestException(string message) : base(message) { }
}

public abstract class NotFoundException : CetusFoodException
{
    protected NotFoundException(string message) : base(message) { }
}

