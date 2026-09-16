using HotelBookingAPI.Controllers.HotelRooms.GetAvailableRooms;
using HotelBookingAPI.Controllers.Hotels.GetHotel;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Tests.Hotels.GetHotel
{
    public class GetHotelUnitTests
    {
        [Test]
        public async Task GetHotelSuccess()
        {

            var mediatrMock = new MediatrMock();
            var controller = new GetHotelController();


            var result = await controller.Get(mediatrMock.Object, "hello");

            var OkResult = result as OkObjectResult;
            Assert.AreEqual(200, OkResult!.StatusCode);
        }

        [Test]
        public async Task GetHotelFailureHotelNameRequired()
        {
            var mediatrMock = new MediatrMock();
            var controller = new GetHotelController();


            var result = await controller.Get(mediatrMock.Object, String.Empty);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(400, badRequestResult!.StatusCode);
        }
    }
}
