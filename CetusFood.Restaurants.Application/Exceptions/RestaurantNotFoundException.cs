using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Application.Exceptions;

public class RestaurantNotFoundException : CetusFoodException
{
    public RestaurantNotFoundException() : base("Restaurant was not found")
    {
    }
}