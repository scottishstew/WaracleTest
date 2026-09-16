using HotelBookingAPI.Core.Queries.GetAvailableRooms;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Core.Queries.GetHotel;

namespace HotelBookingAPI.Core.Domain
{
    public interface IHotelRepository
    {
        Task<List<GetHotelQueryResult>> GetHotelByName(string name);
        Task<HotelRoom?> GetHotelRoom(Guid hotelId, Guid hotelRoomId);
        Task<List<GetAvailableRoomsQueryResult>> GetAvailableRooms(DateTime fromDate, DateTime toDate, int numberOfPeople);
        Task<GetBookingQueryResult?> GetBooking(string bookingReference);
        Task<bool> BookingOverlaps(Guid HotelId, Guid HotelRoomId, DateTime fromDate, DateTime toDate);
        Task<bool> HotelRoomExists(Guid HotelId, Guid HotelRoomId);
        Task<Hotel?> GetHotelById(Guid hotelId);
        Task<bool> HotelExists(Guid HotelId);
        Task BookRoom(HotelRoomBooking hotelRoomBooking);
        Task AddHotel(Hotel hotels);
        Task AddHotelRoom(HotelRoom hotelRooms);

    }
}
