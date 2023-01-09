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
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateFormResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddRestaurant()
    {
        return Ok();
    }
    
    [HttpPost("{id:guid}/delivery-price")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateFormResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SetRestaurantDeliveryPrice(Guid id)
    {
        return Ok();
    }
    
    [HttpPatch("{id:guid}/open-hours")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateRestaurantOpenHours(Guid id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFormCarOffersResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ArchiveRestaurant(Guid id)
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateRestaurant(Guid id)
    {
        return Ok();
    }
}