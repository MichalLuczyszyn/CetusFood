using CetusFood.Restaurants.Application.Queries.GetRestaurant;
using CetusFood.Restaurants.Application.Queries.GetRestaurants;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using CetusFood.Restaurants.Infrastructure.EF.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CetusFood.Restaurants.Infrastructure.Queries.GetRestaurants;

public class GetRestaurantsHandler : IRequestHandler<GetRestaurantsQuery, GetRestaurantsResponse>
{
    private readonly RestaurantDbContext _dbContext;
    private readonly DbSet<Restaurant> _restaurants;

    public GetRestaurantsHandler(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
        _restaurants = dbContext.Restaurants;
    }
    public async Task<GetRestaurantsResponse> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurants
            .Select(x => new GetRestaurantResponse(x.Id,x.Name, x.Address, x.PhoneNumber, x.OpenHour, x.CloseHour, x.RestaurantDeliveryPrices
                .Where(x => !x.IsArchived)
                .Select(y => new GetRestaurantDeliveryPriceResponse(y.DeliveryCost, y.MinimalOrderValue, y.FreeOrderDeliveryThreshold)).FirstOrDefault()))
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetRestaurantsResponse(restaurant);
    }
}