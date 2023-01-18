using MediatR;

namespace CetusFood.Restaurants.Application.Commands.Update;

public record UpdateRestaurantCommand(Guid Id, string Name, string Address, string PhoneNumber) : IRequest;
public record UpdateRestaurantRequest(string Name, string Address, string PhoneNumber);