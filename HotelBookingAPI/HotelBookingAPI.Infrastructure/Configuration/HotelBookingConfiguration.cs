using HotelBookingAPI.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingAPI.Infrastructure.Configuration
{
    public class HotelBookingConfiguration : IEntityTypeConfiguration<HotelRoomBooking>
    {
        public void Configure(EntityTypeBuilder<HotelRoomBooking> builder)
        {
            builder
              .ToTable("HotelRoomBookings", "Hotel")
              .HasKey(t => t.HotelRoomBookingId);

            builder.Property(p => p.HotelRoomBookingId)
                .IsRequired();

            builder.Property(p => p.HotelId)
                .IsRequired();


            builder.Property(p => p.HotelRoomId)
                .IsRequired();

            builder.Property(i => i.NumberOfGuests);

            builder.Property(i => i.BookingReference);

            builder.Property(i => i.BookerName);

            builder.Property(i => i.FromDate);

            builder.Property(i => i.ToDate);

            builder.HasOne(i => i.Hotel)
                .WithMany(i => i.Bookings)
                .HasForeignKey(i => i.HotelId);
  
        }
    }
}
