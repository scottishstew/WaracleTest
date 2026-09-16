namespace HotelBookingAPI.Core.Queries.GetHotel
{
    public class GetHotelQueryResult
    {
        public Guid HotelId { get; }
        public string HotelName { get; }

        public GetHotelQueryResult(Guid hotelId, string hotelName)
        {
            HotelId = hotelId;
            HotelName = hotelName;
        }
    }
}
