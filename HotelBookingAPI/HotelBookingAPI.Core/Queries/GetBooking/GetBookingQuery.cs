using MediatR;

namespace HotelBookingAPI.Core.Queries.GetBooking
{
    /// <summary>
    /// Retrieves a booking by its reference number
    /// </summary>
    public class GetBookingQuery : IRequest<GetBookingQueryResult?>
    {
        public string BookingReference { get; }

        public GetBookingQuery(string bookingReference)
        {
            BookingReference = bookingReference;
        }

    }
}
