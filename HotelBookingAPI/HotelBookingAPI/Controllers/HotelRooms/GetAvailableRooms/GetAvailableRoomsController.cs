using HotelBookingAPI.Core.Queries.GetAvailableRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers.HotelRooms.GetAvailableRooms
{   
    /// <summary>
    /// Lists the rooms available in the hotels
    /// </summary>
    [Route("v1/hotels")]
    [ApiController]
    public class GetAvailableRoomsController : ControllerBase
    {
        /// <summary>
        /// Lists the rooms available in the hotels
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="numberOfPeople"></param>
        /// <returns></returns>
        [HttpGet("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate,
            [FromQuery] int numberOfPeople)
        {
            if (fromDate == DateTime.MinValue || toDate == DateTime.MinValue)
                return BadRequest("Invalid date times");

            if (toDate < fromDate)
                return BadRequest("To date cannot be less than from date");

            if (numberOfPeople == 0)
                return BadRequest("Number of people must be greater than 0");

            var availableRooms = await mediator.Send(new GetAvailableRoomsQuery(fromDate, toDate, numberOfPeople));

            return Ok(availableRooms);
        }
    }

}
