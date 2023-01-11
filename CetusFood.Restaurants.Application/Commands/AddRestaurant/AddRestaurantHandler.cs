using CetusFood.Common.Abstractions.Dtos;
using CetusFood.Restaurants.Application.Repositories;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using MediatR;

namespace CetusFood.Restaurants.Application.Commands.AddRestaurant;

public class AddRestaurantHandler : IRequestHandler<AddRestaurantCommand, ObjectCreatedDto>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public AddRestaurantHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }
    public async Task<ObjectCreatedDto> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = new Restaurant(request.Name, request.Address, request.PhoneNumber, request.OpenHour, request.CloseHour);

        var response = await _restaurantRepository.AddAsync(restaurant);

        return new ObjectCreatedDto(response);
    }
}