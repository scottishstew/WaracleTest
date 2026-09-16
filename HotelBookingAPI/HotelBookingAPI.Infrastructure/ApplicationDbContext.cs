using HotelBookingAPI.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Infrastructure
{

    public class ApplicationDbContext : DbContext
    {
        /*
            DbSets for hotel entity collections
        */
        public DbSet<Hotel> Hotels { get; set; } = null!;
        public DbSet<HotelRoom> HotelRooms { get; set; } = null!;
        public DbSet<HotelRoomBooking> HotelRoomBookings { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load the basic Identity configuration
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); 
        }


    }
}
