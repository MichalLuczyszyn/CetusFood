using CetusFood.Restaurants.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CetusFood.Restaurants.Infrastructure.EF.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseConnection(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RestaurantDbContext>(x => x.UseSqlServer(connectionString));
    }
}