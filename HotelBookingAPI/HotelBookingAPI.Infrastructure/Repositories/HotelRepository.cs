using HotelBookingAPI.Core.Domain;
using HotelBookingAPI.Core.Queries.GetAvailableRooms;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Core.Queries.GetHotel;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BookingOverlaps(Guid hotelId, Guid hotelRoomId, DateTime fromDate, DateTime toDate)
        {
            return await _context.HotelRoomBookings
            .AnyAsync(booking => booking.HotelId == hotelId 
                        && booking.HotelRoomId == hotelRoomId 
                        && fromDate < booking.ToDate 
                        && toDate > booking.FromDate
                     );
        }

        public async Task BookRoom(HotelRoomBooking hotelRoomBooking)
        {
            _context.HotelRoomBookings.Add(hotelRoomBooking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetAvailableRoomsQueryResult>> GetAvailableRooms(DateTime fromDate, DateTime toDate, int numberOfPeople)
        {
            return await _context.HotelRooms.Where
                (room => !room.Bookings.Any(booking => fromDate < booking.ToDate && toDate > booking.FromDate)
        
                && ((room.RoomType == HotelRoomType.Single && numberOfPeople == 1)
                || (room.RoomType == HotelRoomType.Double && numberOfPeople <= 2)
                || (room.RoomType == HotelRoomType.Deluxe && numberOfPeople <= 4)
                ))
                .Select(booking => new GetAvailableRoomsQueryResult(
                    booking.Hotel.HotelName, 
                    booking.RoomNumber, 
                    booking.RoomType.ToString(),
                    fromDate, 
                    toDate))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> HotelExists(Guid hotelId)
        {
            return await _context.Hotels.AnyAsync(i => i.HotelId == hotelId);
        }

        public async Task<GetBookingQueryResult?> GetBooking(string bookingReference)
        {
            return await _context.HotelRoomBookings.Where(booking => booking.BookingReference == bookingReference)
                .Select(result => new GetBookingQueryResult(result.BookingReference, 
                                       result.BookerName, 
                                       result.NumberOfGuests,
                                       result.Hotel.HotelName, 
                                       result.HotelRoom.RoomNumber,
                                       result.HotelRoom.RoomType.ToString(),
                                       result.FromDate, result.ToDate))
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }

        public async Task<List<GetHotelQueryResult>> GetHotelByName(string name)
        {
            return await _context.Hotels.Where(hotel => hotel.HotelName.Contains(name))
                .Select(h => new GetHotelQueryResult(h.HotelId, h.HotelName))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Hotel?> GetHotelById(Guid hotelId)
        {
            return await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.HotelId == hotelId);
        }

        public async Task<HotelRoom?> GetHotelRoom(Guid hotelId, Guid hotelRoomId)
        {
            return await _context.HotelRooms.FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.HotelRoomId == hotelRoomId);
        }

        public async Task<bool> HotelRoomExists(Guid HotelId, Guid HotelRoomId)
        {
            return await _context.HotelRooms.AnyAsync(hr => hr.HotelId == HotelId && hr.HotelRoomId ==  HotelRoomId);
        }

        public async Task<bool> BookingExists(string bookingReference)
        {
            return await _context.HotelRoomBookings.AnyAsync(booking => booking.BookingReference == bookingReference);
        }

        public async Task AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task AddHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRooms.Add(hotelRoom);
            await _context.SaveChangesAsync();
        }
    }
}
