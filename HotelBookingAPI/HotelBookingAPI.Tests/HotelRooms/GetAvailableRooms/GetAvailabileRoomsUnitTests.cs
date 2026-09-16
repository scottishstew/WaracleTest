using HotelBookingAPI.Controllers.Bookings.BookRoom;
using HotelBookingAPI.Controllers.Bookings.GetBooking;
using HotelBookingAPI.Controllers.HotelRooms.GetAvailableRooms;
using HotelBookingAPI.Core.Domain;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Tests.HotelRooms.GetAvailableRooms
{
    public class GetAvailabileRoomsUnitTests
    {
        [Test]
        public async Task GetAvailableRoomsSuccess()
        {
            var booking = new GetBookingQueryResult("123454", "Stew", 2, "Stew's hotel", 2, HotelRoomType.Double.ToString(), DateTime.UtcNow, DateTime.UtcNow.AddDays(2));

            var mediatrMock = new MediatrMock(getBookingResult: booking);
            var controller = new GetAvailableRoomsController();

            var fromDate = DateTime.UtcNow;
            var toDate = DateTime.UtcNow.AddDays(7);
         
            var result = await controller.Get(mediatrMock.Object, fromDate, toDate, 1);

            var OkResult = result as OkObjectResult;
            Assert.AreEqual(200, OkResult!.StatusCode);
        }

        [Test]
        public async Task GetAvailableRoomsFailureInvalidDates()
        {
            var mediatrMock = new MediatrMock();
            var controller = new GetAvailableRoomsController();

            var fromDate = DateTime.MinValue;
            var toDate = DateTime.UtcNow.AddDays(7);
         
            var result = await controller.Get(mediatrMock.Object, fromDate, toDate, 1);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Invalid date times", badRequestResult.Value);
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }

        [Test]
        public async Task GetAvailableRoomsFailureToDateInPast()
        {
            var mediatrMock = new MediatrMock();
            var controller = new GetAvailableRoomsController();

            var fromDate = DateTime.UtcNow;
            var toDate = DateTime.UtcNow.AddDays(-7);
            
            var result = await controller.Get(mediatrMock.Object, fromDate, toDate, 1);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("To date cannot be less than from date", badRequestResult.Value);
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }

        [Test]
        public async Task GetAvailableRoomsFailureNumberOfPeopleInvalid()
        {
            var mediatrMock = new MediatrMock();
            var controller = new GetAvailableRoomsController();

            var fromDate = DateTime.UtcNow;
            var toDate = DateTime.UtcNow.AddDays(7);

            var result = await controller.Get(mediatrMock.Object, fromDate, toDate, 0);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Number of people must be greater than 0", badRequestResult.Value);
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }
    }
}
