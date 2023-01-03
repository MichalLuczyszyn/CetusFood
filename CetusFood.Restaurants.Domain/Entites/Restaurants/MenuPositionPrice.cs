using CetusFood.Restaurants.Domain.Common;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants;

public class MenuPositionPrice : ArchivableEntity
{
    public MenuPositionPrice(decimal price, DateTimeOffset date, Guid menuPositionId)
    {
        Id = Guid.NewGuid();
        GuardBeforeZeroValue(price);
        Price = price;
        Date = date;
        MenuPositionId = menuPositionId;
    }
    public decimal Price { get; private set; }
    public DateTimeOffset Date { get; private set; }
    
    public MenuPosition MenuPosition { get; private set; }
    public Guid MenuPositionId { get; private set; }
    
    private static void GuardBeforeZeroValue(decimal? value)
    {
        if (value < 0) throw new ValueIsLessThanZeroException();
    }
}