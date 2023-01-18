using MediatR;

namespace CetusFood.Restaurants.Application.Commands.SetDeliveryPrice;

public record SetRestaurantDeliveryPriceCommand(decimal DeliveryCost, decimal MinimalOrderValue, decimal? FreeOrderDeliveryThreshold, DateTimeOffset Date, Guid Id) : IRequest;
public record SetRestaurantDeliveryPriceRequest(decimal DeliveryCost, decimal MinimalOrderValue, decimal? FreeOrderDeliveryThreshold, DateTimeOffset Date) : IRequest;