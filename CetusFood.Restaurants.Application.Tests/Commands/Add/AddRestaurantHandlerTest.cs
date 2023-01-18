using CetusFood.Restaurants.Application.Commands.Add;
using CetusFood.Restaurants.Application.Exceptions;
using CetusFood.Restaurants.Application.Repositories;
using CetusFood.Restaurants.Domain.Entites.Restaurants;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CetusFood.Restaurants.Application.Tests.Commands.Add;

public class AddRestaurantHandlerTest
{
    private readonly IRestaurantRepository _restaurantRepository = Substitute.For<IRestaurantRepository>();
    private readonly CancellationToken _cancellationToken = CancellationToken.None;
    private readonly AddRestaurantHandler _handler;
    public AddRestaurantHandlerTest()
    {
        _handler = new AddRestaurantHandler(_restaurantRepository);
    }

    [Fact]
    public async void Given_CreateRestaurant_When_RequestDataIsCorrectNameIsUnique_Then_CreateRestaurant()
    {
        //arange
        var request = new AddRestaurantCommand("Name", "Address", "123456789", 8, 15);
        _restaurantRepository.AnyAsync(Arg.Any<string>()).Returns(false);
        
        //act
        await _handler.Handle(request, _cancellationToken);

        await _restaurantRepository.Received(1).AddAsync(Arg.Any<Restaurant>());
    }    
    
    [Fact]
    public async void Given_CreateRestaurant_When_RequestDataIsCorrectNameIsNotUnique_Then_ShouldThrowRestaurantNameIsAlreadyTakenException()
    {
        //arange
        var request = new AddRestaurantCommand("Name", "Address", "123456789", 8, 15);
        _restaurantRepository.AnyAsync(Arg.Any<string>()).Returns(true);
        
        //act
        var act = async () => await _handler.Handle(request, _cancellationToken);


        await act.Should().ThrowAsync<RestaurantNameIsAlreadyTakenException>();
    }
}