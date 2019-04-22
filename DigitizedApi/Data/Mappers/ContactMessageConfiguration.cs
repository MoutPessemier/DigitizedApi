using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizedApi.Data.Mappers {
    public class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage> {
        public void Configure(EntityTypeBuilder<ContactMessage> builder) {
            builder.ToTable("Contact Message");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Topic)
                .IsRequired(true);

            builder.Property(c => c.Content)
                .IsRequired();

            builder.Property(c => c.Date)
                .IsRequired(true);
        }
    }
}
