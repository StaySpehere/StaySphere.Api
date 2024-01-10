using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);


            builder.HasMany(c => c.Rooms)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId);

            builder.Property(c => c.Name)
                .HasMaxLength(255);
            builder.Property(c => c.Price)
                .HasColumnType("money");
        }
    }
}
