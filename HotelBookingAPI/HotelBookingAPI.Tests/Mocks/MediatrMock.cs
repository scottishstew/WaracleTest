using HotelBookingAPI.Core.Commands.BookRoom;
using HotelBookingAPI.Core.Queries.GetAvailableRooms;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Core.Queries.GetHotel;
using HotelBookingAPI.Core.Queries.HotelExists;
using HotelBookingAPI.Core.Queries.HotelRoomExists;
using MediatR;
using Moq;

namespace HotelBookingAPI.Tests.Mocks
{
    public class MediatrMock : Mock<IMediator>
    {
        public MediatrMock(GetBookingQueryResult? getBookingResult = null,
                           List<GetAvailableRoomsQueryResult>? getAvailableRoomsResult = null,
                            string? bookRoomResult = null,
                           List<GetHotelQueryResult>? getHotelResult = null,
                           bool hotelExistsResult = true,
                           bool hotelRoomExistsResult = true
                           ) 
        {
            Setup(s => s.Send(It.IsAny<BookRoomCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(bookRoomResult));
            Setup(s => s.Send(It.IsAny<GetAvailableRoomsQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(getAvailableRoomsResult ?? null));
            Setup(s => s.Send(It.IsAny<GetBookingQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(getBookingResult ?? null));
            Setup(s => s.Send(It.IsAny<GetHotelQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(getHotelResult ?? new List<GetHotelQueryResult>()));
            Setup(s => s.Send(It.IsAny<HotelExistsQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(hotelExistsResult));
            Setup(s => s.Send(It.IsAny<HotelRoomExistsQuery>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(hotelRoomExistsResult));

        }

    }
}
