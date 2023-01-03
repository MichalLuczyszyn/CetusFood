using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CetusFood.Restaurants.API.Controllers;

[AllowAnonymous]
[Route("restaurants")]
public class RestaurantController : ControllerBase
{
    [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFormResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetRestaurants()
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFormResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetRestaurant(Guid id)
    {
        return Ok();
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
    public async Task<ActionResult> SetRestaurantDeliveryPrice()
    {
        return Ok();
    }
    
    [HttpPatch("{id:guid}/open-hours")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateRestaurantOpenHours()
    {
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFormCarOffersResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ArchiveRestaurant()
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> UpdateRestaurant()
    {
        return Ok();
    }
}