using System.Text.RegularExpressions;
using CetusFood.Restaurants.Domain.Common;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants;

public sealed class Restaurant : ArchivableEntity
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string PhoneNumber { get; private set; }
    public short OpenHour { get; private set; }
    public short CloseHour { get; private set; }

    public ICollection<RestaurantDeliveryPrice> RestaurantDeliveryPrices { get; private set; } = new List<RestaurantDeliveryPrice>();


    private const int MaximumCharacters = 100;
    private const short MinimumHours = 0;
    private const short MaximumHours = 24;
    private const string PatternTwo = "^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$";

    public Restaurant(string name, string address, string phoneNumber, short openHour, short closeHour)
    {
        Id = Guid.NewGuid();
        GuardBeforeTooLongNames(name);
        Name = name;
        GuardBeforeTooLongNames(address);
        Address = address;
        GuardBeforeInvalidPhoneNumber(phoneNumber);
        PhoneNumber = phoneNumber;
        ChangeOpenHours(openHour, closeHour);
    }

    public void AddRestaurantDeliveryPrice(RestaurantDeliveryPrice restaurantDeliveryPrice, DateTimeOffset currentDateTimeOffset)
    {
        var timeSpan = currentDateTimeOffset - restaurantDeliveryPrice.Date;
        var daysPassed = timeSpan.Days;

        if (daysPassed > 30 || currentDateTimeOffset < restaurantDeliveryPrice.Date)
            throw new InvalidDeliveryPriceDateException();
        
        ArchiveCurrentDeliveryPrice();
        if (RestaurantDeliveryPrices.Any(x => !x.IsArchived)) throw new RestaurantAlreadyHaveDeliveryPriceSetException();
        
        RestaurantDeliveryPrices.Add(restaurantDeliveryPrice);
    }

    public void ChangeOpenHours(short openHour, short closeHour)
    {
        GuardBeforeIncorrectHours(openHour);
        OpenHour = openHour;
        GuardBeforeIncorrectHours(closeHour);
        CloseHour = closeHour;
    }
    
    private void ArchiveCurrentDeliveryPrice()
    {
        var restaurantDeliveryPrice = RestaurantDeliveryPrices.FirstOrDefault(x => !x.IsArchived);

        restaurantDeliveryPrice?.Archive();
    }

    public void Update(string name, string address, string phoneNumber)
    {
        if (IsArchived) throw new RestaurantIsAlreadyArchived();
        
        GuardBeforeTooLongNames(name);
        Name = name;
        GuardBeforeTooLongNames(address);
        Address = address;
        GuardBeforeInvalidPhoneNumber(phoneNumber);
        PhoneNumber = phoneNumber;
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
        if (string.IsNullOrEmpty(phoneNumber)) throw new PhoneNumberIsInvalidException();
        var phoneIsValid = new Regex(PatternTwo).IsMatch(phoneNumber);
        if (!phoneIsValid)
            throw new PhoneNumberIsInvalidException();
    }
}