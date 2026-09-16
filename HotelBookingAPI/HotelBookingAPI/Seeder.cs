using HotelBookingAPI.Core.Domain;

namespace HotelBookingAPI
{
    public class Seeder
    {

        private readonly IConfiguration _configuration;
        private readonly IHotelRepository _hotelRepository;

   
        public Seeder(IConfiguration configuration,
                            IHotelRepository hotelRepository)
        {
            _configuration = configuration;
            _hotelRepository = hotelRepository;
        }

        /// <summary>
        /// Seed default hotels in to the database
        /// </summary>
        /// <returns></returns>
        public async Task SeedHotels()
        {
            var hotels = _configuration
          .GetSection("Hotels")
          .GetChildren()
          .Select(c => GetHotel(c))
          .ToList();

            if (hotels != null && hotels.Count > 0)
            {
                foreach (var hotel in hotels)
                {
                    var hotelinDB = await _hotelRepository.GetHotelById(hotel.HotelId);

                    if (hotelinDB == null)
                        await _hotelRepository.AddHotel(hotel);
                }
            }
            
        }

        /// <summary>
        /// Seed hotel rooms into the database
        /// </summary>
        /// <returns></returns>
        public async Task SeedHotelRooms()
        {
          var hotelRooms = _configuration
          .GetSection("HotelRooms")
          .GetChildren()
          .Select(c => GetHotelRoom(c))
          .ToList();

            if (hotelRooms != null && hotelRooms.Count > 0)
            {
                foreach (var hotelRoom in hotelRooms)
                {
                    var hotelRoominDB = await _hotelRepository.GetHotelRoom(hotelRoom.HotelId, hotelRoom.HotelRoomId);

                    if (hotelRoominDB == null)
                         await _hotelRepository.AddHotelRoom(hotelRoom);
                }
            }     
        }

        private static Hotel GetHotel(IConfigurationSection c)
        {
            var hotelId = c.GetSection("HotelId").Get<Guid>();
            var hotelName = c.GetSection("HotelName").Get<string>();

            return new Hotel(hotelId, hotelName!);
    
        }

        private static HotelRoom GetHotelRoom(IConfigurationSection c)
        {
            var hotelRoomId = c.GetSection("HotelRoomId").Get<Guid>();
            var hotelId = c.GetSection("HotelId").Get<Guid>();
            var roomType = c.GetSection("RoomType").Get<string>();
            var roomNumber = c.GetSection("RoomNumber").Get<int>();

            var roomTypeConverted = (HotelRoomType)Enum.Parse(typeof(HotelRoomType), roomType!); 

            return new HotelRoom(hotelRoomId, hotelId, roomTypeConverted, roomNumber);
        }
    }


}
