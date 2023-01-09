using CetusFood.Restaurants.Application.Queries.GetRestaurant;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using CetusFood.Restaurants.Infrastructure.EF.Context;
using CetusFood.Restaurants.Infrastructure.Queries.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CetusFood.Restaurants.Infrastructure.Queries.GetRestaurant;

public class GetRestaurantHandler : IRequestHandler<GetRestaurantQuery, GetRestaurantResponse>
{
    private readonly RestaurantDbContext _dbContext;
    private readonly DbSet<Restaurant> _restaurants;

    public GetRestaurantHandler(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
        _restaurants = dbContext.Restaurants;
    }
    public async Task<GetRestaurantResponse> Handle(GetRestaurantQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurants.Where(x => x.Id == request.Id)
            .Select(x => new GetRestaurantResponse(x.Name, x.Address, x.PhoneNumber, x.OpenHour, x.CloseHour, x.RestaurantDeliveryPrices
                .Where(x => !x.IsArchived)
                .Select(y => new GetRestaurantDeliveryPriceResponse(y.DeliveryCost, y.MinimalOrderValue, y.FreeOrderDeliveryThreshold)).FirstOrDefault()))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (restaurant is null) throw new RestaurantWasNotFoundException();

        return restaurant;
    }
}