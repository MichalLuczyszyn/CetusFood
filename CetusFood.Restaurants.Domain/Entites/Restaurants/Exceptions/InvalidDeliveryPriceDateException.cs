using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class InvalidDeliveryPriceDateException : BadRequestException
{
    public InvalidDeliveryPriceDateException() : base("Price cannot be applied to future date and more than 30 days in past")
    {
    }
}