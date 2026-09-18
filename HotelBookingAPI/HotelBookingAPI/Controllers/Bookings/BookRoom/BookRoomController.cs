using HotelBookingAPI.Core.Commands.BookRoom;
using HotelBookingAPI.Core.Queries.HotelExists;
using HotelBookingAPI.Core.Queries.HotelRoomExists;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers.Bookings.BookRoom
{      
    /// <summary>
    /// Books a hotel room subject to the rooms availability
    /// </summary>
    [Route("v1/hotels")]
    [ApiController]
    public class BookRoomController : ControllerBase
    {
        /// <summary>
        /// Books a hotel room subject to the rooms availability
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post(
            [FromServices] IMediator mediator,
            [FromBody] BookRoomRequest request)
        {
            if (request.FromDate == DateTime.MinValue || request.ToDate == DateTime.MinValue)
                return BadRequest("Invalid date times");

            if (request.ToDate.Date <= request.FromDate.Date)
                return BadRequest("To date cannot be less than or the same as from date");

            if (string.IsNullOrWhiteSpace(request.BookerName))
                return BadRequest("Booker name is required");

            if (request.NumberOfGuests <= 0)
                return BadRequest("Invalid number of guests");

            var hotelExists = await mediator.Send(new HotelExistsQuery(request.HotelId));

            if (!hotelExists)
                return NotFound("Hotel not found");

            var hotelRoomExists = await mediator.Send(new HotelRoomExistsQuery(request.HotelId, request.HotelRoomId));

            if (!hotelRoomExists)
                return NotFound("Hotel room not found");

            var bookingReference = DateTime.UtcNow.Ticks.ToString();

            var error = await mediator.Send(new BookRoomCommand(request.HotelId, request.HotelRoomId, bookingReference, request.FromDate, request.ToDate, request.BookerName, request.NumberOfGuests));

            if (error != null)
                return Conflict(error);

            return Ok();
        }
    }
}
