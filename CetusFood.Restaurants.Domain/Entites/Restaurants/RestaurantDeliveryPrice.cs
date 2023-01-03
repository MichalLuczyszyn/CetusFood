using CetusFood.Restaurants.Domain.Common;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;

namespace CetusFood.Restaurants.Domain.Entites.Restaurants;

public class RestaurantDeliveryPrice : ArchivableEntity
{
    public RestaurantDeliveryPrice(decimal deliveryCost, decimal minimalOrderValue, decimal? freeOrderDeliveryThreshold, DateTimeOffset date, Guid restaurantId)
    {
        Id = Guid.NewGuid();
        GuardBeforeZeroValue(deliveryCost);
        DeliveryCost = deliveryCost;
        GuardBeforeZeroValue(minimalOrderValue);
        MinimalOrderValue = minimalOrderValue;
        GuardBeforeZeroValue(freeOrderDeliveryThreshold);
        FreeOrderDeliveryThreshold = freeOrderDeliveryThreshold;
        Date = date;
        RestaurantId = restaurantId;
    }
    public decimal DeliveryCost { get; private set; }
    public decimal MinimalOrderValue { get; private set; }
    public decimal? FreeOrderDeliveryThreshold { get; private set; }
    public DateTimeOffset Date { get; private set; }
    
    public Restaurant Restaurant { get; private set; }
    public Guid RestaurantId { get; private set; }

    private static void GuardBeforeZeroValue(decimal? value)
    {
        if (value < 0) throw new ValueIsLessThanZeroException();
    }
}