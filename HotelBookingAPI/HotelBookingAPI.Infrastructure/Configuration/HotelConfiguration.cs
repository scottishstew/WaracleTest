using HotelBookingAPI.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBookingAPI.Infrastructure.Configuration
{

    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        /// <summary>
        /// Hotel EF Core configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
            .ToTable("Hotels", "Hotel")
            .HasKey(t => t.HotelId);

            builder.Property(p => p.HotelId)
                .IsRequired();

            builder.Property(p => p.HotelName)
                .IsRequired();

            builder.HasMany(i => i.HotelRooms)
                .WithOne(i => i.Hotel)
                .HasForeignKey(i => i.HotelId);
        }
    }
}
