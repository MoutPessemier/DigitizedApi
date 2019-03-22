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

        public void Delete(MyImage image) {
            _images.Remove(image);
        }

        public IEnumerable<MyImage> GetAll() {
            return _images.OrderBy(i => i.Name).ToList();
        }

        public MyImage GetById(int id) {
            return _images.SingleOrDefault(i => i.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void Update(MyImage image) {
            _images.Update(image);
        }
    }
}
