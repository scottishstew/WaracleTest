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
            FromDate = fromDate;
            ToDate = toDate;
            BookerName = bookerName;
            NumberOfGuests = numberOfGuests;
        }
    }
}
