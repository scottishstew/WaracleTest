using HotelBookingAPI.Core.Queries.GetBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers.Bookings.GetBooking
{
    /// <summary>
    /// Searches for a booking in the system via a booking reference
    /// </summary>
    [Route("v1/hotels")]
    [ApiController]
    public class GetBookingController : ControllerBase
    {
        /// <summary>
        /// Searches for a booking in the system via a booking reference
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="bookingReference"></param>
        /// <returns></returns>
        [HttpGet("rooms/bookings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromQuery] string bookingReference)
        {
            var booking = await mediator.Send(new GetBookingQuery(bookingReference));

            if (booking == null)
                return NotFound("Booking not found");

            return Ok(booking);
        }
    }

}
