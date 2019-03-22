using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DigitizedApi.Data.Repositories {
    public class VisitorRepository : IVisitorRepository {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Visitor> _visitors;

        public VisitorRepository(ApplicationDbContext context) {
            _context = context;
            _visitors = _context.Visitors;
        }

        public void AddVisitor(Visitor visitor) {
            _visitors.Add(visitor);
        }

        public Visitor GetBy(string email) {
            return _visitors.Include(v => v.Liked).ThenInclude(v => v.Image).SingleOrDefault(v => v.Email == email);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
