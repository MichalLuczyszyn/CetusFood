using CetusFood.Restaurants.Domain.Entites.Restaurants;
using CetusFood.Restaurants.Domain.Entites.Restaurants.Exceptions;
using FluentAssertions;
using Xunit;

namespace CetusFood.Restaurants.Domain.Tests;

public class RestaurantDomainTest
{
    [Fact]
    public void Given_AddRestaurantDeliveryPrice_When_RestaurantIsNotArchivedAndHaveDeliveryPrice_Then_ShouldArchiveCurrentDeliveryPriceAndAddNew()
    {
        // Arrange
        var currentDateTime = DateTimeOffset.Now;
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18);
        var deliveryPrice1 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());
        var deliveryPrice2 = new RestaurantDeliveryPrice(20, 30, 40, currentDateTime.AddDays(1), Guid.NewGuid());
        restaurant.RestaurantDeliveryPrices.Add(deliveryPrice1);

        // Act
        restaurant.AddRestaurantDeliveryPrice(deliveryPrice2, currentDateTime.AddDays(2));

        // Assert
        deliveryPrice1.IsArchived.Should().BeTrue();
        restaurant.RestaurantDeliveryPrices.Should().Contain(deliveryPrice2);
    }

    [Fact]
    public void Given_AddRestaurantDeliveryPrice_When_DeliveryPriceDateIsPlacedInFuture_Then_ShouldThrowInvalidDeliveryPriceDateException()
    {
        // Arrange
        var currentDateTime = DateTimeOffset.Now;
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18);
        var deliveryPrice1 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());

        var act = () => restaurant.AddRestaurantDeliveryPrice(deliveryPrice1, currentDateTime.AddDays(-2));

        // Assert
        act.Should().Throw<InvalidDeliveryPriceDateException>();
    }

    [Fact]
    public void Given_AddRestaurantDeliveryPrice_When_MoreThan30DaysHavePassed_Then_ShouldThrowInvalidDeliveryPriceDateException()
    {
        // Arrange
        var currentDateTime = DateTimeOffset.Now;
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18);
        var deliveryPrice1 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime.AddDays(-40), Guid.NewGuid());

        var act = () => restaurant.AddRestaurantDeliveryPrice(deliveryPrice1, currentDateTime);

        // Assert
        act.Should().Throw<InvalidDeliveryPriceDateException>();
    }

    [Fact]
    public void Given_AddRestaurantDeliveryPrice_When_OneOrMoreDeliveryPriceIsNotArchived_Then_ShouldThrowRestaurantAlreadyHaveDeliveryPriceSetException()
    {
        // Arrange
        var currentDateTime = DateTimeOffset.Now;
        var deliveryPrice2 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());
        var deliveryPrice3 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18)
        {
            RestaurantDeliveryPrices = { deliveryPrice2, deliveryPrice3 }
        };

        var deliveryPrice1 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());

        var act = () => restaurant.AddRestaurantDeliveryPrice(deliveryPrice1, currentDateTime);

        // Assert
        act.Should().Throw<RestaurantAlreadyHaveDeliveryPriceSetException>();
    }

    [Theory]
    [InlineData(8, 18)]
    [InlineData(8, 18)]
    [InlineData(8, 18)]
    [InlineData(25, 18)]
    [InlineData(8, 25)]
    [InlineData(-1, 18)]
    [InlineData(8, -1)]
    [InlineData(8, 8)]
    public void Given_ChangeRestaurantDeliveryPrice(short openHour, short closeHour)
    {
        // Act
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18);

        var act = () => restaurant.ChangeOpenHours(openHour, closeHour);

        // Assert
        act.Should().Throw<Exception>();
    }

    [Fact]
    public void Given_ChangeRestaurantDeliveryPrice_When_OneOrMoreDeliveryPriceIsNotArchived_Then_ShouldThrowRestaurantAlreadyHaveDeliveryPriceSetException()
    {
        // Arrange
        var currentDateTime = DateTimeOffset.Now;
        var deliveryPrice2 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());
        var deliveryPrice3 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());
        var restaurant = new Restaurant("name", "address", "1234567890", 8, 18)
        {
            RestaurantDeliveryPrices = { deliveryPrice2, deliveryPrice3 }
        };

        var deliveryPrice1 = new RestaurantDeliveryPrice(10, 20, 30, currentDateTime, Guid.NewGuid());

        var act = () => restaurant.AddRestaurantDeliveryPrice(deliveryPrice1, currentDateTime);

        // Assert
        act.Should().Throw<RestaurantAlreadyHaveDeliveryPriceSetException>();
    }
}