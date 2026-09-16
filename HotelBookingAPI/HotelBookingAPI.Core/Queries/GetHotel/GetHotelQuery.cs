using MediatR;

namespace HotelBookingAPI.Core.Queries.GetHotel
{
    /// <summary>
    /// Gets a Hotel branch
    /// </summary>
    public class GetHotelQuery : IRequest<List<GetHotelQueryResult>>
    {
        public string HotelName { get; }

        public GetHotelQuery(string hotelName)
        {
            HotelName = hotelName;
        }
    }
}
