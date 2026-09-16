using HotelBookingAPI.Core.Domain;

namespace HotelBookingAPI.Tests.Domain
{
    public class HotelRoomBookingTests
    {

        [Test]
        public async Task ValidateSingleRoomSuccess()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId,hotelId, HotelRoomType.Single, 5);
            var outcome = room.ValidateGuestCount(1);

            Assert.AreEqual(true, outcome);
        }

        [Test]
        public async Task ValidateDoubleRoomSuccess()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId, hotelId, HotelRoomType.Double, 5);
            var outcome = room.ValidateGuestCount(2);

            Assert.AreEqual(true, outcome);
        }

        [Test]
        public async Task ValidateDeluxeRoomSuccess()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId, hotelId, HotelRoomType.Deluxe, 5);
            var outcome = room.ValidateGuestCount(3);

            Assert.AreEqual(true, outcome);
        }

        [Test]
        public async Task ValidateSingleRoomFailure()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId, hotelId, HotelRoomType.Single, 5);
            var outcome = room.ValidateGuestCount(2);

            Assert.AreEqual(false, outcome);
        }

        [Test]
        public async Task ValidateDoubleRoomFailure()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId, hotelId, HotelRoomType.Single, 5);
            var outcome = room.ValidateGuestCount(5);

            Assert.AreEqual(false, outcome);
        }

        [Test]
        public async Task ValidateDeluxeRoomFailure()
        {
            var hotelId = Guid.NewGuid();
            var roomId = Guid.NewGuid();

            HotelRoom room = new HotelRoom(roomId, hotelId, HotelRoomType.Single, 5);
            var outcome = room.ValidateGuestCount(5);

            Assert.AreEqual(false, outcome);
        }
    }
}
