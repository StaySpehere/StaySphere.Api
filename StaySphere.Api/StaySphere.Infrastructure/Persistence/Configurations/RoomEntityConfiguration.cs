using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable(nameof(Room));
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Category)
                .WithMany(c => c.Rooms)
                .HasForeignKey(r => r.CategoryId);
            builder.HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId);

            builder.Property(r => r.Number);
            builder.Property(r => r.Floor);
        }
    }
}
