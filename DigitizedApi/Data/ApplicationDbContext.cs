using DigitizedApi.Data.Mappers;
using DigitizedApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitizedApi.Data {
    public class ApplicationDbContext : IdentityDbContext {

        public DbSet<MyImage> Images { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new VisitorConfiguration());
            builder.ApplyConfiguration(new ImageVisitorConfiguration());
        }
    }
}
