using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class PropertyNameIsTooLongException : BadRequestException
{
    public PropertyNameIsTooLongException() : base("Property name is too long")
    {
    }
}