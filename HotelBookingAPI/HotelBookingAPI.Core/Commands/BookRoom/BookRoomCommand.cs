using MediatR;

namespace HotelBookingAPI.Core.Commands.BookRoom
{
    public class BookRoomCommand : IRequest<string?>
    {
        public Guid HotelId { get; }
        public Guid HotelRoomId { get; }
        public string BookingReference { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public string BookerName { get; }
        public int NumberOfGuests { get; }

        /// <summary>
        /// Books a hotel room to a guest
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="hotelRoomId"></param>
        /// <param name="bookingReference"></param>
        /// <param name="bookerName"></param>
        /// <param name="numberOfGuests"></param>
        public BookRoomCommand(Guid hotelId, Guid hotelRoomId, string bookingReference, DateTime fromDate, DateTime toDate, string bookerName, int numberOfGuests)
        {
            HotelId = hotelId;
            HotelRoomId = hotelRoomId;
            BookingReference = bookingReference;

            // Assuming each hotel only allows guests to check in at 3pm, then checkout at 12pm
            FromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 15,0,0);
            ToDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 12, 0, 0);
            
            BookerName = bookerName;
            NumberOfGuests = numberOfGuests;
        }
    }
}
