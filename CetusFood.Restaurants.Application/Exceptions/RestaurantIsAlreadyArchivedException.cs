using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Application.Exceptions;

public class RestaurantIsAlreadyArchivedException : CetusFoodException
{
    public RestaurantIsAlreadyArchivedException() : base("Restaurant is already archived")
    {
    }
}