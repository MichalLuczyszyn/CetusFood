using MediatR;

namespace CetusFood.Restaurants.Application.Queries.GetRestaurant;

public record GetRestaurantQuery(Guid Id) : IRequest<GetRestaurantResponse>;