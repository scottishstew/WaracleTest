using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.HotelRoomExists
{
    /// <summary>
    /// Checks if a hotel room exists and returns true or false.
    /// </summary>
    public class HotelRoomExistsQuery : IRequest<bool>
    {
        public Guid HotelId { get; }
        public Guid HotelRoomId { get; }

        public HotelRoomExistsQuery(Guid hotelId, Guid hotelRoomId)
        {
            HotelId = hotelId;
            HotelRoomId = hotelRoomId;
        }

    }
}
