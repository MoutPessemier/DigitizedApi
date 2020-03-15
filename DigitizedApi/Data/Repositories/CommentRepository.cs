using DigitizedApi.Models;
using DigitizedApi.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DigitizedApi.Data.Repositories {
    public class CommentRepository : ICommentRepository {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<MyImage> _images;
        private readonly DbSet<Comment> _comments;

        public CommentRepository(ApplicationDbContext context) {
            _context = context;
            _images = _context.Images;
            _comments = _context.Comments;
        }

        public void Add(Comment comment) {
            _comments.Add(comment);
        }

        public void Delete(Comment comment) {
            _comments.Remove(comment);
        }

        public IEnumerable<Comment> GetAll(MyImage image) {
            return _comments.Where(c => c.MyImageId == image.Id).OrderBy(c => c.Date).ToList();
        }

        public Comment GetById(int id) {
            return _comments.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void Update(Comment comment) {
            _context.Update(comment);
        }
    }
}
