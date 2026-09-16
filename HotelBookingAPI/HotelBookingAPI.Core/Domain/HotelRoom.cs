namespace HotelBookingAPI.Core.Domain
{
    public class HotelRoom
    {
        public Guid HotelRoomId { get; }
        public Guid HotelId { get; }
        public HotelRoomType RoomType { get; }
        public int RoomNumber { get; }

        // Navigation Properties
        public Hotel Hotel { get; }
        public List<HotelRoomBooking> Bookings { get; }

        public HotelRoom(Guid hotelRoomId, Guid hotelId, HotelRoomType roomType, int roomNumber)
        {
            HotelRoomId = hotelRoomId;
            HotelId = hotelId;
            RoomType = roomType;
            RoomNumber = roomNumber;
            Hotel = default!;
            Bookings = default!;
        }

        public bool ValidateGuestCount(int guestCount)
        {
            if (guestCount == 0)
                return false;

            if (RoomType == HotelRoomType.Single && guestCount > 1)
                return false;

            if (RoomType == HotelRoomType.Double && guestCount > 2)
                return false;
            
            if (RoomType == HotelRoomType.Deluxe && guestCount > 4)
                return false;
            

            return true;
        }
    }
}
