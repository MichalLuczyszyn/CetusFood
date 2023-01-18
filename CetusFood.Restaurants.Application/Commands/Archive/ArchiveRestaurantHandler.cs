using CetusFood.Restaurants.Application.Exceptions;
using CetusFood.Restaurants.Application.Repositories;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.Archive;

public class ArchiveRestaurantHandler : IRequestHandler<ArchiveRestaurantCommand>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public ArchiveRestaurantHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    public async Task<Unit> Handle(ArchiveRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetAsync(request.Id);

        if (restaurant is null) throw new RestaurantNotFoundException();
        
        restaurant.Archive();

        await _restaurantRepository.SaveChangesAsync();
        
        return Unit.Value;
    }
}