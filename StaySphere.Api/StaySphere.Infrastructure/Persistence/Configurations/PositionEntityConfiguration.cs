using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class PositionEntityConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(nameof(Position));
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId);

            builder.Property(p => p.Name)
                .HasMaxLength(255);
            builder.Property(p => p.Salary)
                .HasColumnType("money");
        }
    }
}
