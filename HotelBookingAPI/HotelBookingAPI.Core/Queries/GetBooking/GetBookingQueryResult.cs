namespace HotelBookingAPI.Core.Queries.GetBooking
{
    public class GetBookingQueryResult
    {
        public string BookingReference { get; }
        public string BookerName { get; }
        public int NumberOfGuests { get; }
        public string HotelName { get; }
        public string RoomType { get; }
        public int RoomNumber { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

        public GetBookingQueryResult(string bookingReference, string bookerName, int numberOfGuests, string hotelName, int roomNumber, string roomType, DateTime fromDate, DateTime toDate)
        {
            BookingReference = bookingReference;
            BookerName = bookerName;
            NumberOfGuests = numberOfGuests;
            HotelName = hotelName;
            RoomNumber = roomNumber;
            RoomType = roomType;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
