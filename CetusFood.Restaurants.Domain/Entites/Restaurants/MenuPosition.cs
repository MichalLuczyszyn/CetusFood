using CetusFood.Restaurants.Domain.Common;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants;

public class MenuPosition : ArchivableEntity
{
    private const int MaximumCharacters = 100;
    public MenuPosition(string name, DateTimeOffset date, MenuPositionType menuPositionType, bool availability)
    {
        Id = Guid.NewGuid();
        GuardBeforeTooLongNames(name);
        Name = name;
        Date = date;
        MenuPositionType = menuPositionType;
        Availability = availability;
    }
    public string Name { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public MenuPositionType MenuPositionType { get; private set; }
    public bool Availability { get; private set; }
    public ICollection<MenuPositionPrice> MenuPositionPrices { get; private set; }
    
    public void AddMenuPositionName(MenuPositionPrice menuPositionPrice, DateTimeOffset currentDateTimeOffset)
    {
        var timeSpan =  currentDateTimeOffset - menuPositionPrice.Date;
        var daysPassed = timeSpan.Days;

        if (daysPassed > 30 || currentDateTimeOffset < menuPositionPrice.Date)
            throw new InvalidDeliveryPriceDateException();

        var currentMenuPositionPrice = MenuPositionPrices.FirstOrDefault(x => !x.IsArchived);
        if(currentMenuPositionPrice is not null)
            if (currentMenuPositionPrice.Price > menuPositionPrice.Price)
                throw new NewPriceCannotBeLowerThanOldException();
        
        ArchiveCurrentDeliveryPrice();
        if (MenuPositionPrices.Any(x => !x.IsArchived)) throw new RestaurantAlreadyHaveDeliveryPriceSetException();
        
        MenuPositionPrices.Add(menuPositionPrice);
    }

    public void Update(string name, MenuPositionType menuPositionType, bool availability)
    {
        if (IsArchived) throw new MenuPositionIsAlreadyArchivedException();
        
        GuardBeforeTooLongNames(name);
        Name = name;
        MenuPositionType = menuPositionType;
        Availability = availability;
    }
    
    private void ArchiveCurrentDeliveryPrice()
    {
        var restaurantDeliveryPrice = MenuPositionPrices.FirstOrDefault(x => !x.IsArchived);

        restaurantDeliveryPrice?.Archive();
    }
    
    private static void GuardBeforeTooLongNames(string value)
    {
        if (string.IsNullOrEmpty(value)) throw new PropertyNameIsInvalidException();
        if (value.Length > MaximumCharacters) throw new PropertyNameIsTooLongException();
    }
}

public enum MenuPositionType : short
{
    NoData = 0,
    Single = 10,
    Group = 20
}