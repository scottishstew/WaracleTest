using HotelBookingAPI.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingAPI.Infrastructure.Configuration
{
    public class HotelRoomConfiguration : IEntityTypeConfiguration<HotelRoom>
    {
        /// <summary>
        /// HotelRoom EF Core configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<HotelRoom> builder)
        {
            builder
            .ToTable("HotelRooms", "Hotel")
            .HasKey(t => t.HotelRoomId);

            builder.Property(p => p.HotelRoomId)
                .IsRequired();

            builder.Property(p => p.HotelId)
                .IsRequired();

            builder.Property(p => p.RoomType)
                .IsRequired()
                .HasConversion(
                v => v.ToString(),
                v => (HotelRoomType)Enum.Parse(typeof(HotelRoomType), v, true));

            builder.Property(p => p.RoomNumber)
                .IsRequired();

            builder.HasOne(i => i.Hotel)
                .WithMany(i => i.HotelRooms)
                .HasForeignKey(i => i.HotelId);

            builder.HasMany(i => i.Bookings)
                .WithOne(i => i.HotelRoom)
                .HasForeignKey(i => i.HotelRoomId);
        }
    }
}