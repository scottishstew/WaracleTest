using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, GetBookingQueryResult?>
    {

        private readonly IHotelRepository _hotelRepository;

        public GetBookingQueryHandler(IHotelRepository repository)
        {
            _hotelRepository = repository;
        }

        public async Task<GetBookingQueryResult?> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _hotelRepository.GetBooking(request.BookingReference);
        }
    }
}
