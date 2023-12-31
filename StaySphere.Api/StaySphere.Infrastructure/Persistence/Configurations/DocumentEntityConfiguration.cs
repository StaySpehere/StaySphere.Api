using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Document = StaySphere.Domain.Entities.Document;

namespace StaySphere.Infrastructure.Persistence.Configurations
{
    public class DocumentEntityConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document");
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Guests)
                .WithOne(g => g.Document)
                .HasForeignKey(g => g.DocumentId);

            builder.Property(d => d.SerialNumber);
            builder.Property(d => d.FirstName)
                .HasMaxLength(255);
            builder.Property(d => d.LastName)
                .HasMaxLength(255);
            builder.Property(d => d.BrithDate)
                .HasColumnType("date");
            builder.Property(d => d.Gender)
                .HasMaxLength(255);



        }
    }
}
