using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DigitizedApi.Data.Mappers {
    public class ImageVisitorConfiguration : IEntityTypeConfiguration<LikedImage> {
        public void Configure(EntityTypeBuilder<LikedImage> builder) {
            builder.HasKey(i => new { i.ImageId, i.VisitorId });

            //builder.HasOne(i => i.Visitor)
            //    .WithMany(v => v.Liked)
            //    .HasForeignKey(i => i.VisitorId);

            //builder.HasOne(i => i.Image)
            //    .WithMany()
            //    .HasForeignKey(i => i.ImageId);
        }
    }
}
