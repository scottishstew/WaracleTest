namespace HotelBookingAPI.Core.Domain
{
    public class Hotel
    {
        public Guid HotelId { get; }
        public string HotelName { get; }

        // Navigation Properties
        public List<HotelRoom> HotelRooms { get; }
        public List<HotelRoomBooking> Bookings { get; }
        public Hotel(Guid hotelId, string hotelName)
        {
            HotelId = hotelId;
            HotelName = hotelName;
            HotelRooms = default!;
            Bookings = default!;
        }
    }
}
