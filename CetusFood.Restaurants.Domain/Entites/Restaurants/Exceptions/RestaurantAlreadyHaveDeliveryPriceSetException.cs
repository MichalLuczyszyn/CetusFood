using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class RestaurantAlreadyHaveDeliveryPriceSetException : BadRequestException
{
    public RestaurantAlreadyHaveDeliveryPriceSetException() : base("Restaurant already have delivery price")
    {
    }
}