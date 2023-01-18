using CetusFood.Restaurants.Domain.Entites.Restaurants;

namespace CetusFood.Restaurants.Application.Repositories;

public interface IRestaurantRepository
{
    Task<bool> AnyAsync(string name);
    Task<Restaurant?> GetAsync(Guid id);
    Task<Guid> AddAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
    Task SaveChangesAsync();
}