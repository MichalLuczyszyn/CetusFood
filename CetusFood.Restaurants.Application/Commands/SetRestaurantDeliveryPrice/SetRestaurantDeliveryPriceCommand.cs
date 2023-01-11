using MediatR;

namespace CetusFood.Restaurants.Application.Commands.SetRestaurantDeliveryPrice;

public record SetRestaurantDeliveryPriceCommand(decimal DeliveryCost, decimal MinimalOrderValue, decimal? FreeOrderDeliveryThreshold, DateTimeOffset Date, Guid Id) : IRequest;