using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(nameof(Booking));
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Employee)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EmployeeId);

            builder.HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId);

            builder.HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId);

            builder.Property(b => b.CheckInData)
                .HasColumnType("date")
                .IsRequired(true);
            builder.Property(b => b.CheckOutData)
                .HasColumnType("date")
                .IsRequired(true);
            builder.Property(b => b.TotalPrice)
                .HasColumnType("money");
        }
    }
}
