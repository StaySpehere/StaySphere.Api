using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable(nameof(Review));
            builder.HasKey(b => b.Id);

            builder.HasOne(r => r.Booking)
                 .WithMany(b => b.Reviews)
                 .HasForeignKey(r => r.BookingId);

            builder.Property(r => r.Comment)
                .HasMaxLength(255);
            builder.Property(r => r.Grade)
                .HasColumnType("decimal(18,4)");
        }
    }
}
