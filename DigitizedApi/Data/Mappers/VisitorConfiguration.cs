using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizedApi.Data.Mappers {
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor> {
        public void Configure(EntityTypeBuilder<Visitor> builder) {
            builder.ToTable("Visitors");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.FirstName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(v => v.FirstName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(v => v.Email)
                .HasMaxLength(70)
                .IsRequired(true);

            builder.Property(v => v.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired(true);

            builder.HasMany(c => c.Comments)
                .WithOne()
                .HasForeignKey(c => c.VisitorId);
        }
    }
}
