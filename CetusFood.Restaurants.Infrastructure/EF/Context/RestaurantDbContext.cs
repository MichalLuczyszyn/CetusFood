using CetusFood.Restaurants.Domain.Entites.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace CetusFood.Restaurants.Infrastructure.EF.Context;

public class RestaurantDbContext : DbContext
{
    public DbSet<MenuPosition> MenuPositions { get; set; }
    public DbSet<MenuPositionPrice> MenuPositionPrices { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<RestaurantDeliveryPrice> RestaurantDeliveryPrices { get; set; }
    
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}