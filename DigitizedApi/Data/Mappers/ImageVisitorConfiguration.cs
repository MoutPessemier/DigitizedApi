using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizedApi.Data.Mappers {
    public class ImageVisitorConfiguration : IEntityTypeConfiguration<LikedImage> {
        public void Configure(EntityTypeBuilder<LikedImage> builder) {
            builder.HasKey(i => new { i.ImageId, i.VisitorId });
        }
    }
}
