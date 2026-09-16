using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.HotelExists
{
    public class HotelExistsQueryHandler : IRequestHandler<HotelExistsQuery, bool>
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelExistsQueryHandler(IHotelRepository repository)
        {
            _hotelRepository = repository;
        }

        public async Task<bool> Handle(HotelExistsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelRepository.HotelExists(request.HotelId);
        }
    }
}
