using System.Collections.Generic;
using System.Linq;
using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitizedApi.Data.Repositories {
    public class VideoRepository : IVideoRepository {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<MyVideo> _videos;

        public VideoRepository(ApplicationDbContext context) {
            _context = context;
            _videos = _context.Videos;
        }

        public void Add(MyVideo video) {
            _videos.Add(video);
        }

        public IEnumerable<MyVideo> GetAll() {
            return _videos.OrderBy(v => v.Id).ToList();
        }

        public MyVideo GetById(int id) {
            return _videos.FirstOrDefault(v => v.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

    }
}
