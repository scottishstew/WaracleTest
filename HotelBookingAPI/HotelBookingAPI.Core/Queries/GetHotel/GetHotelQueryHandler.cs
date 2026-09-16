using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.GetHotel
{
    public class GetHotelQueryHandler : IRequestHandler<GetHotelQuery, List<GetHotelQueryResult>>
    {
        private readonly IHotelRepository _hotelRepository;

        public GetHotelQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<List<GetHotelQueryResult>> Handle(GetHotelQuery request, CancellationToken cancellationToken)
        {
            return await _hotelRepository.GetHotelByName(request.HotelName);
        }
    }
}
