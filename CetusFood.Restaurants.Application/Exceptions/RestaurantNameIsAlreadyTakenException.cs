using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Application.Exceptions;

public class RestaurantNameIsAlreadyTakenException : CetusFoodException
{
    public RestaurantNameIsAlreadyTakenException() : base("Given restaurant name is already taken")
    {
    }
}