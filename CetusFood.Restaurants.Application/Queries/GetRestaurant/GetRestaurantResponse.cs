namespace CetusFood.Restaurants.Application.Queries.GetRestaurant;

public record GetRestaurantResponse(Guid Id, string Name, string Address, string PhoneNumber, short OpenHour, short CloseHour, GetRestaurantDeliveryPriceResponse RestaurantDeliveryPrice);
public record GetRestaurantDeliveryPriceResponse(decimal DeliveryCost, decimal MinimalOrderValue, decimal? FreeOrderDeliveryThreshold);