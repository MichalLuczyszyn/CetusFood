using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class RestaurantIsAlreadyArchived : BadRequestException
{
    public RestaurantIsAlreadyArchived() : base("Restaureant is already archived")
    {
    }
}