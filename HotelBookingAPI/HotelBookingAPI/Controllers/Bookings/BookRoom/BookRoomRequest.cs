using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Controllers.Bookings.BookRoom
{
    public class BookRoomRequest
    {
        [Required]
        public Guid HotelId { get; set; }

        [Required]
        public Guid HotelRoomId { get; set; }

        [Required]
        public string BookerName { get; set; } = default!;

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public DateTime FromDate { get; set;}

        [Required]
        public DateTime ToDate { get; set; }
        
    }
}
