using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class NewPriceCannotBeLowerThanOldException : BadRequestException
{
    public NewPriceCannotBeLowerThanOldException() : base("New price cannot be lower than old price")
    {
    }
}