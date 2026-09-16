using HotelBookingAPI.Controllers.Bookings.BookRoom;
using HotelBookingAPI.Core.Domain;
using HotelBookingAPI.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Tests.Bookings.BookRoom
{
    public class BookRoomUnitTests
    {
        [Test]
        public async Task BookRoomSuccess()
        {
            var mediatrMock = new MediatrMock();
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 1, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.BookerName = "Stew";
            request.FromDate = DateTime.UtcNow;
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Post(mediatrMock.Object, request);

            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult!.StatusCode);
        }

        [Test]
        public async Task BookRoomFailureBookerNameRequired()
        {
            var mediatrMock = new MediatrMock();
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Post(mediatrMock.Object, request);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Booker name is required", badRequestResult.Value);
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }


        [Test]
        public async Task BookRoomFailureInvalidDates()
        {
            var mediatrMock = new MediatrMock();
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.MinValue;
            request.BookerName = "Stew";
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Post(mediatrMock.Object, request);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Invalid date times", badRequestResult.Value);
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }

        [Test]
        public async Task BookRoomFailureTooManyGuests()
        {
            var mediatrMock = new MediatrMock(bookRoomResult: "Too many guests for this room type");
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.BookerName = "Stew";
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 6;

            var result = await controller.Post(mediatrMock.Object, request);

            var conflictResult = result as ConflictObjectResult;
            Assert.AreEqual("Too many guests for this room type", conflictResult.Value);
            Assert.AreEqual(409, conflictResult!.StatusCode);
        }

        [Test]
        public async Task BookRoomFailureAlreadyBooked()
        {
            var mediatrMock = new MediatrMock(bookRoomResult: "This room is already booked for this date range");
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.BookerName = "Stew";
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 6;

            var result = await controller.Post(mediatrMock.Object, request);

            var conflictResult = result as ConflictObjectResult;
            Assert.AreEqual("This room is already booked for this date range", conflictResult.Value);
            Assert.AreEqual(409, conflictResult!.StatusCode);
        }


        [Test]
        public async Task BookRoomFailureHotelNotFound()
        {
            var mediatrMock = new MediatrMock(hotelExistsResult: false);
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.BookerName = "Stew";
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Post(mediatrMock.Object, request);

            var notFoundResult = result as NotFoundObjectResult;
            Assert.AreEqual("Hotel not found", notFoundResult.Value);
            Assert.AreEqual(404, notFoundResult!.StatusCode);
        }

        [Test]
        public async Task BookRoomFailureHotelRoomNotFound()
        {
            var mediatrMock = new MediatrMock(hotelRoomExistsResult: false);
            var booking = new HotelRoomBooking(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "1234h", DateTime.UtcNow, DateTime.UtcNow.AddDays(7), 6, "Stew");
            var controller = new BookRoomController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.BookerName = "Stew";
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Post(mediatrMock.Object, request);

            var notFoundResult = result as NotFoundObjectResult;
            Assert.AreEqual("Hotel room not found", notFoundResult.Value);
            Assert.AreEqual(404, notFoundResult!.StatusCode);
        }
    }
}
