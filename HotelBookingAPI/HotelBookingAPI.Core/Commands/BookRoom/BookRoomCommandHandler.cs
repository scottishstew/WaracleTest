using HotelBookingAPI.Core.Domain;
using MediatR;

namespace HotelBookingAPI.Core.Commands.BookRoom
{
    public class BookRoomCommandHandler : IRequestHandler<BookRoomCommand, string?>
    {

        private readonly IHotelRepository _hotelRepository;

        public BookRoomCommandHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        
        public async Task<string?> Handle(BookRoomCommand request, CancellationToken cancellationToken)
        {
            HotelRoom? room = await _hotelRepository.GetHotelRoom(request.HotelId, request.HotelRoomId);

            if (!room!.ValidateGuestCount(request.NumberOfGuests))
                return "Too many guests for this room type";

            bool overlaps = await _hotelRepository.BookingOverlaps(request.HotelId, request.HotelRoomId, request.FromDate, request.ToDate);

            if (overlaps)
                return "This room is already booked for this date range";

            HotelRoomBooking booking = new HotelRoomBooking(Guid.NewGuid(), request.HotelId, request.HotelRoomId, request.BookingReference, request.FromDate, request.ToDate, request.NumberOfGuests, request.BookerName);

            await _hotelRepository.BookRoom(booking);

            return null;

        }
    }
}
