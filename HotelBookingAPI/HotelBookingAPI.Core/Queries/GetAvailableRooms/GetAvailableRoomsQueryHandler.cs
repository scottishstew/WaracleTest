using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Queries.GetAvailableRooms
{
    public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, List<GetAvailableRoomsQueryResult>>
    {
        private readonly IHotelRepository _hotelRepository;
        
        public GetAvailableRoomsQueryHandler(IHotelRepository repository)
        {
            _hotelRepository = repository;
        }

        public async Task<List<GetAvailableRoomsQueryResult>> Handle(GetAvailableRoomsQuery request, CancellationToken cancellationToken)
        {
            return await _hotelRepository.GetAvailableRooms(request.FromDate, request.ToDate, request.NumberOfPeople);
        }
    }
}
