using DigitizedApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitizedApi.Data.Mappers {
    public class CommentConfiguration : IEntityTypeConfiguration<Comment> {
        public void Configure(EntityTypeBuilder<Comment> builder) {
            builder.ToTable("Comment");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Author)
                .IsRequired(true);

            builder.Property(c => c.Content)
                .IsRequired(true);

            builder.Property(c => c.Date)
                .IsRequired(true);
        }
    }
}
