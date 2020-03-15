using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<Visitor> GetAll() {
            return _visitors.OrderBy(v => v.FirstName).ToList();
        }

        public Visitor GetById(string email) {
            return _visitors
                .Include(v => v.Comments).SingleOrDefault(v => v.Email == email);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
