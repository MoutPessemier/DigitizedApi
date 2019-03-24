using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizedApi.Data.Mappers {
    public class VideoConfiguration : IEntityTypeConfiguration<MyVideo> {
        public void Configure(EntityTypeBuilder<MyVideo> builder) {
            builder.ToTable("Video");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.URL)
                .IsRequired(true);
        }
    }
}
