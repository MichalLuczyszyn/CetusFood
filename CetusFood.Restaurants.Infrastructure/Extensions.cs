using System.Reflection;
using CetusFood.Restaurants.Application.Repositories;
using CetusFood.Restaurants.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CetusFood.Restaurants.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IRestaurantRepository, RestaurantRepository>();

        return services;
    }
}