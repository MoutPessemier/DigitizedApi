using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitizedApi.Data.Repositories {
    public class ImageRepository : IImageRepository {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<MyImage> _images;

        public ImageRepository(ApplicationDbContext context) {
            _context = context;
            _images = _context.Images;
        }

        public void Add(MyImage image) {
            _images.Add(image);
        }

        public IEnumerable<MyImage> GetAll() {
            return _images.Include(i => i.Comments).OrderBy(i => i.Name).ToList();
        }

        public MyImage GetById(int id) {
            return _images.Include(i => i.Comments).SingleOrDefault(i => i.Id == id);
        }

        public MyImage GetByIdNoTracking(int id) {
            return _images.AsNoTracking().Include(i => i.Comments).SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Comment> GetComments(int id) {
            return _images.Include(i => i.Comments).FirstOrDefault(i => i.Id == id).Comments.OrderBy(c => c.Date).ToList();
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
