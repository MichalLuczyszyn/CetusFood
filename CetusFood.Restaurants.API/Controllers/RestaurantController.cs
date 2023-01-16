using CetusFood.Common.Abstractions.Dtos;
using CetusFood.Restaurants.Application.Commands.Add;
using CetusFood.Restaurants.Application.Commands.Archive;
using CetusFood.Restaurants.Application.Commands.SetDeliveryPrice;
using CetusFood.Restaurants.Application.Commands.SetOpenHours;
using CetusFood.Restaurants.Application.Commands.Update;
using CetusFood.Restaurants.Application.Queries.GetRestaurant;
using CetusFood.Restaurants.Application.Queries.GetRestaurants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CetusFood.Restaurants.API.Controllers;

[AllowAnonymous]
[Route("restaurants")]
public class RestaurantController : ControllerBase
{
    private readonly IMediator _mediator;

    public RestaurantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRestaurantsResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetRestaurants([FromQuery] GetRestaurantsQuery query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetRestaurantResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetRestaurant([FromRoute] Guid id)
    {
        var query = new GetRestaurantQuery(id);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObjectCreatedDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ObjectCreatedDto>> AddRestaurant([FromBody] AddRestaurantCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("{id:guid}/delivery-price")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SetRestaurantDeliveryPrice([FromRoute] Guid id, [FromBody] SetRestaurantDeliveryPriceRequest request)
    {
        await _mediator.Send(new SetRestaurantDeliveryPriceCommand(request.DeliveryCost, request.MinimalOrderValue, request.FreeOrderDeliveryThreshold, request.Date, id));
        return NoContent();
    }

    [HttpPatch("{id:guid}/open-hours")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateRestaurantOpenHours([FromRoute] Guid id, [FromBody] UpdateRestaurantOpenHoursRequest request)
    {
        var command = new UpdateRestaurantOpenHoursCommand(id, request.OpenHour, request.CloseHour);
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ArchiveRestaurant([FromRoute] Guid id)
    {
        await _mediator.Send(new ArchiveRestaurantCommand(id));
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateRestaurant([FromRoute] Guid id, [FromBody] UpdateRestaurantRequest request)
    {
        await _mediator.Send(new UpdateRestaurantCommand(id, request.Name, request.Address, request.PhoneNumber));
        return NoContent();
    }
}