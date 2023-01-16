using CetusFood.Common.Abstractions.Extensions;
using CetusFood.Restaurants.Application.Exceptions;
using CetusFood.Restaurants.Application.Repositories;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.SetDeliveryPrice;

public class SetRestaurantDeliveryPriceHandler : IRequestHandler<SetRestaurantDeliveryPriceCommand>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IClock _clock;

    public SetRestaurantDeliveryPriceHandler(IRestaurantRepository restaurantRepository, IClock clock)
    {
        _restaurantRepository = restaurantRepository;
        _clock = clock;
    }
    public async Task<Unit> Handle(SetRestaurantDeliveryPriceCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetAsync(request.Id);

        if (restaurant is null) throw new RestaurantNotFoundException();
        
        if (restaurant.IsArchived) throw new RestaurantIsAlreadyArchivedException();
        
        var restaurantDeliveryPrice = new RestaurantDeliveryPrice(request.DeliveryCost, request.MinimalOrderValue, request.FreeOrderDeliveryThreshold, request.Date, request.Id);
        
        restaurant.AddRestaurantDeliveryPrice(restaurantDeliveryPrice, _clock.CurrentDateTimeOffset());

        await _restaurantRepository.SaveChangesAsync();
        
        return Unit.Value;
    }
}