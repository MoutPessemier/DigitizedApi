using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            builder.Property(v => v.Telephone)
                .HasMaxLength(15)
                .IsRequired(true);
            builder.Ignore(v => v.LikedImages);

            builder.HasMany(c => c.Comments)
                .WithOne()
                .HasForeignKey(c => c.VisitorId);
        }
    }
}
