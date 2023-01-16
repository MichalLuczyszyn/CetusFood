using MediatR;

namespace CetusFood.Restaurants.Application.Commands.SetOpenHours;

public record UpdateRestaurantOpenHoursCommand(Guid Id, short OpenHour, short CloseHour) : IRequest;

public record UpdateRestaurantOpenHoursRequest( short OpenHour, short CloseHour);