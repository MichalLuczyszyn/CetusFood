using CetusFood.Common.Abstractions.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CetusFood.Common.Abstractions;

public static class CommonExtensions
{
    public static IServiceCollection AddCommonExtensions(this IServiceCollection services)
    {
        services.AddTransient<IClock, UtcClock>();

        return services;
    }
}