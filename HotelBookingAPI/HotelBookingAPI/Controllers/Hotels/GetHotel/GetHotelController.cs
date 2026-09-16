using HotelBookingAPI.Core.Queries.GetHotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers.Hotels.GetHotel
{
    /// <summary>
    /// Searches for hotels via its name
    /// </summary>
    [Route("v1/hotels")]
    [ApiController]
    public class GetHotelController : ControllerBase
    {
        /// <summary>
        /// Searches for hotels via its name
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromQuery] string hotelName)
        {
            if (String.IsNullOrWhiteSpace(hotelName))
                return BadRequest("Hotel name is required");

            var booking = await mediator.Send(new GetHotelQuery(hotelName));

            return Ok(booking);
        }
    }
}
