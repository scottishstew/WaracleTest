using MediatR;

namespace HotelBookingAPI.Core.Queries.HotelExists
{
    /// <summary>
    /// Checks if a hotel exists in the database by its ID
    /// </summary>
    public class HotelExistsQuery : IRequest<bool>
    {
        public Guid HotelId { get; }

        public HotelExistsQuery(Guid hotelId) { 
        
            HotelId = hotelId;
        }

    }
}
