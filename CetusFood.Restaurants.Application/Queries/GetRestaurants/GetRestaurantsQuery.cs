using MediatR;

namespace CetusFood.Restaurants.Application.Queries.GetRestaurants;

public record GetRestaurantsQuery() : IRequest<GetRestaurantsResponse>;