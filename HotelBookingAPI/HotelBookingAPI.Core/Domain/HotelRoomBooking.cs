namespace HotelBookingAPI.Core.Domain
{
    public class HotelRoomBooking
    {
        public Guid HotelRoomBookingId { get; }
        public Guid HotelId { get; }
        public Guid HotelRoomId { get; }
        public string BookingReference { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public int NumberOfGuests { get; }
        public string BookerName { get; }

        // Navigation Properties
        public Hotel Hotel { get; }
        public HotelRoom HotelRoom { get; }
       

        public HotelRoomBooking(Guid hotelRoomBookingId, Guid hotelId, Guid hotelRoomId, string bookingReference, DateTime fromDate, DateTime toDate, int numberOfGuests, string bookerName)
        {
            HotelRoomBookingId = hotelRoomBookingId;
            HotelId = hotelId;
            HotelRoomId = hotelRoomId;
            BookingReference = bookingReference;
            FromDate = fromDate;
            ToDate = toDate;
            NumberOfGuests = numberOfGuests;
            BookerName = bookerName;
            Hotel = default!;
            HotelRoom = default!;
        }
    }
}
