using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class ValueIsLessThanZeroException : BadRequestException
{
    public ValueIsLessThanZeroException() : base("Value is less than zero")
    {
    }
}