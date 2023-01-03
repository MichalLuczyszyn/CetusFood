using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class MenuPositionIsAlreadyArchivedException : BadRequestException
{
    public MenuPositionIsAlreadyArchivedException() : base("Menu position is already archived")
    {
    }
}