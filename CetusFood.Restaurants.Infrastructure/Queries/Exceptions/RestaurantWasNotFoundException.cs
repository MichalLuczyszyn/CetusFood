using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Infrastructure.Queries.Exceptions;

public class RestaurantWasNotFoundException : NotFoundException
{
    public RestaurantWasNotFoundException() : base("Restaurant was not found")
    {
    }
}