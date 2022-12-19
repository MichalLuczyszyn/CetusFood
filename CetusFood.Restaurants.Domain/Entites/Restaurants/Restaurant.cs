using System.Text.RegularExpressions;
using CetusFood.Restaurants.Domain.Common;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants;

public sealed partial class Restaurant : ArchivableEntity
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public short OpenHour { get; private set; }
    public short CloseHour { get; private set; }
    
    private const int MaximumCharacters = 100;
    private const short MinimumHours = 0;
    private const short MaximumHours = 24;

    public Restaurant(string name, string address, string phoneNumber, short openHour, short closeHour)
    {
        Id = Guid.NewGuid();
        GuardBeforeTooLongNames(name);
        Name = name;
        GuardBeforeTooLongNames(address);
        Address = address;
        GuardBeforeInvalidPhoneNumber(phoneNumber);
        PhoneNumber = phoneNumber;
        GuardBeforeIncorrectHours(openHour);
        OpenHour = openHour;
        GuardBeforeIncorrectHours(closeHour);
        CloseHour = closeHour;
    }

    public void Update(string name, string address, string phoneNumber, short openHour, short closeHour)
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        OpenHour = openHour;
        CloseHour = closeHour;
    }

    private static void GuardBeforeTooLongNames(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new PropertyNameIsInvalidException();
        if (value.Length > MaximumCharacters) throw new PropertyNameIsTooLongException();
    }    
    private static void GuardBeforeIncorrectHours(short value)
    {
        if (value is > MaximumHours or < MinimumHours) throw new WorkingHoursOutOfRangeException();
    }

    private static void GuardBeforeInvalidPhoneNumber(string phoneNumber)
    {
        if(string.IsNullOrEmpty(phoneNumber)) throw new PhoneNumberIsInvalidException();
        if (!MyRegex().IsMatch(phoneNumber)) throw new PhoneNumberIsInvalidException();
    }

    [GeneratedRegex("^\\d{8,10}$")]
    private static partial Regex MyRegex();
}