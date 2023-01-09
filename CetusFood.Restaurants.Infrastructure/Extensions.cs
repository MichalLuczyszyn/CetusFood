using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CetusFood.Restaurants.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}