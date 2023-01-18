using CetusFood.Restaurants.Domain.Entites.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CetusFood.Restaurants.Infrastructure.EF.Configurations.RestaurantDeliveryPriceConfiguration;

public class RestaurantDeliveryPriceConfiguration : IEntityTypeConfiguration<RestaurantDeliveryPrice>
{
    public void Configure(EntityTypeBuilder<RestaurantDeliveryPrice> builder)
    {
        builder.HasOne(x => x.Restaurant).WithMany(x => x.RestaurantDeliveryPrices)
            .HasForeignKey(x => x.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.DeliveryCost).HasPrecision(19, 4);
        builder.Property(x => x.FreeOrderDeliveryThreshold).HasPrecision(19, 4);
        builder.Property(x => x.MinimalOrderValue).HasPrecision(19, 4);
    }
}