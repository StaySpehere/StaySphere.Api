using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class GuestEntityConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable(nameof(Guest));
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Document)
                .WithMany(d => d.Guests)
                .HasForeignKey(g => g.DocumentId);
            builder.HasMany(g => g.Bookings)
                .WithOne(b => b.Guest)
                .HasForeignKey(b => b.GuestId);

            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(255);
            builder.Property(b => b.Email)
                .HasMaxLength(255);

        }
    }
}
