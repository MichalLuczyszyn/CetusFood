using CetusFood.Restaurants.Domain.Entites.Restaurants;

namespace CetusFood.Restaurants.Application.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant> GetAsync(Guid id);
    Task<Guid> AddAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task SaveChangesAsync();
}