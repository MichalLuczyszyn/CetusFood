using CetusFood.Common.Abstractions.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

public class PhoneNumberIsInvalidException : BadRequestException
{
    public PhoneNumberIsInvalidException() : base("Phone number is invalid")
    {
    }
}