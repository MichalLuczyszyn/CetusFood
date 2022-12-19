using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class WorkingHoursOutOfRangeException : BadRequestException
{
    public WorkingHoursOutOfRangeException() : base("Working hours is out of range")
    {
    }
}