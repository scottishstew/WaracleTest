using MediatR;

namespace HotelBookingAPI.Core.Queries.GetAvailableRooms
{
    /// <summary>
    /// Returns a list of available rooms from each hotel
    /// </summary>
    public class GetAvailableRoomsQuery : IRequest<List<GetAvailableRoomsQueryResult>>
    {
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public int NumberOfPeople { get; }

        public GetAvailableRoomsQuery(DateTime fromDate, DateTime toDate, int numberOfPeople)
        {
            FromDate = fromDate;
            ToDate = toDate;
            NumberOfPeople = numberOfPeople;
        }
    }
}
