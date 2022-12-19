using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class PropertyNameIsInvalidException : BadRequestException
{
    public PropertyNameIsInvalidException() : base("Property name is invalid")
    {
    }
}