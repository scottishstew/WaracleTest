using HotelBookingAPI.Controllers.Bookings.BookRoom;
using HotelBookingAPI.Controllers.Bookings.GetBooking;
using HotelBookingAPI.Core.Domain;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelBookingAPI.Tests.Bookings.GetBooking
{
    public class GetBookingUnitTests
    {
        [Test]
        public async Task GetBookingSuccess()
        {
            var fromDate = new DateTime(2026, 09, 15);
            var toDate = new DateTime(2026,09,17);
            var booking = new GetBookingQueryResult("123454", "Stew", 2, "Stew's hotel", 2, HotelRoomType.Double.ToString(), fromDate, toDate);

            var mediatrMock = new MediatrMock(getBookingResult: booking);
            var controller = new GetBookingController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Get(mediatrMock.Object, "123454");

            var OkResult = result as OkObjectResult;
            var retvar = (GetBookingQueryResult)OkResult.Value;

            Assert.AreEqual("123454", retvar.BookingReference);
            Assert.AreEqual("Stew", retvar.BookerName);
            Assert.AreEqual(2, retvar.NumberOfGuests);
            Assert.AreEqual("Stew's hotel", retvar.HotelName);
            Assert.AreEqual(2, retvar.RoomNumber);
            Assert.AreEqual(fromDate, retvar.FromDate);
            Assert.AreEqual(toDate, retvar.ToDate);
            Assert.AreEqual(200, OkResult!.StatusCode);
        }

        [Test]
        public async Task BookRoomFailureHotelRoomNotFound()
        {
            var mediatrMock = new MediatrMock();
            var controller = new GetBookingController();

            var request = new BookRoomRequest();
            request.FromDate = DateTime.UtcNow;
            request.ToDate = DateTime.UtcNow.AddDays(7);
            request.NumberOfGuests = 1;

            var result = await controller.Get(mediatrMock.Object, "123454");

            var notFoundResult = result as NotFoundObjectResult;
            Assert.AreEqual("Booking not found", notFoundResult.Value);
            Assert.AreEqual(404, notFoundResult!.StatusCode);
        }
    }
}
