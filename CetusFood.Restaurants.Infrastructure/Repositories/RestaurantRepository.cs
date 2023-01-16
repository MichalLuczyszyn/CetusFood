using CetusFood.Restaurants.Application.Repositories;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using CetusFood.Restaurants.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace CetusFood.Restaurants.Infrastructure.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _dbContext;

    public RestaurantRepository(RestaurantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AnyAsync(string name)
    {
        return await _dbContext.Restaurants.AnyAsync(x => x.Name == name);
    }

    public async Task<Restaurant> GetAsync(Guid id)
    {
        return await _dbContext.Restaurants.Include(x => x.RestaurantDeliveryPrices).Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Guid> AddAsync(Restaurant restaurant)
    {
        _dbContext.Restaurants.Add(restaurant);
        await _dbContext.SaveChangesAsync();

        return restaurant.Id;
    }

    public async Task DeleteAsync(Restaurant restaurant)
    {
        _dbContext.Restaurants.Remove(restaurant);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}