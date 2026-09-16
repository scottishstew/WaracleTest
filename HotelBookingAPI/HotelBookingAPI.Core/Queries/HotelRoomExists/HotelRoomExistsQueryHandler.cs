using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.HotelRoomExists
{
    public class HotelRoomExistsQueryHandler : IRequestHandler<HotelRoomExistsQuery, bool>
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelRoomExistsQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<bool> Handle(HotelRoomExistsQuery request, CancellationToken cancellationToken)
        {
          return  await _hotelRepository.HotelRoomExists(request.HotelId, request.HotelRoomId);
        }
    }
}
