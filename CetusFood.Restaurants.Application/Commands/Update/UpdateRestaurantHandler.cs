using CetusFood.Restaurants.Application.Exceptions;
using CetusFood.Restaurants.Application.Repositories;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.Update;

public class UpdateRestaurantHandler : IRequestHandler<UpdateRestaurantCommand>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public UpdateRestaurantHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<Unit> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetAsync(request.Id);

        if (restaurant is null) throw new RestaurantNotFoundException();

        var isNameAlreadyTaken = await _restaurantRepository.AnyAsync(request.Name);
        if (isNameAlreadyTaken) throw new RestaurantNameIsAlreadyTakenException();

        if (restaurant.IsArchived) throw new RestaurantIsAlreadyArchivedException();
        
        restaurant.Update(request.Name, request.Address, request.PhoneNumber);

        await _restaurantRepository.SaveChangesAsync();

        return Unit.Value;
    }
}