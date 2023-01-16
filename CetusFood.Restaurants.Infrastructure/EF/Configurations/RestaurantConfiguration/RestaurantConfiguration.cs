using CetusFood.Restaurants.Domain.Entites.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CetusFood.Restaurants.Infrastructure.EF.Configurations.RestaurantConfiguration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(x => x.Address).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(100);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}