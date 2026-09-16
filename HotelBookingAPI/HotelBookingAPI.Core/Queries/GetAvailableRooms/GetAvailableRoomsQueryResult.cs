namespace HotelBookingAPI.Core.Queries.GetAvailableRooms
{
    public class GetAvailableRoomsQueryResult
    {
        public string HotelName { get; }
        public int RoomNumber { get; }
        public string RoomType { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

        public GetAvailableRoomsQueryResult(string hotelName, int roomNumber, string roomType, DateTime fromDate, DateTime toDate)
        {
            HotelName = hotelName;
            RoomNumber = roomNumber;
            RoomType = roomType;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
