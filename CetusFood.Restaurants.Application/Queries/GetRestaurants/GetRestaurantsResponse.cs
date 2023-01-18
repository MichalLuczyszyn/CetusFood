using CetusFood.Restaurants.Application.Queries.GetRestaurant;

namespace CetusFood.Restaurants.Application.Queries.GetRestaurants;

public record GetRestaurantsResponse(ICollection<GetRestaurantResponse> RestaurantResponses);