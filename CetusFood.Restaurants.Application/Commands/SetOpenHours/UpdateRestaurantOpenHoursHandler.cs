using CetusFood.Restaurants.Application.Exceptions;
using CetusFood.Restaurants.Application.Repositories;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.SetOpenHours;

public class UpdateRestaurantOpenHoursHandler : IRequestHandler<UpdateRestaurantOpenHoursCommand>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public UpdateRestaurantOpenHoursHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    public async Task<Unit> Handle(UpdateRestaurantOpenHoursCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetAsync(request.Id);

        if (restaurant is null) throw new RestaurantNotFoundException();
        
        if (restaurant.IsArchived) throw new RestaurantIsAlreadyArchivedException();
        
        restaurant.ChangeOpenHours(request.OpenHour, request.CloseHour);

        await _restaurantRepository.SaveChangesAsync();
        
        return Unit.Value;
    }
}