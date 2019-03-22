using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizedApi.Data.Mappers {
    public class ImageConfiguration : IEntityTypeConfiguration<MyImage> {
        public void Configure(EntityTypeBuilder<MyImage> builder) {
            builder.ToTable("Image");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(i => i.Country)
                .HasMaxLength(84)
                .IsRequired(true);

            builder.Property(i => i.Content)
                .IsRequired(true);

            builder.Property(i => i.Aperture)
                .IsRequired(true);

            builder.Property(i => i.ISO)
                .IsRequired(true);

            builder.Property(i => i.ShutterSpeed)
                .IsRequired(true);
        }
    }
}
