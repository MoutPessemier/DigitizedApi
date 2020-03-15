using System.Collections.Generic;

namespace DigitizedApi.Models.Repositories
{
    public interface ICommentRepository {
        IEnumerable<Comment> GetAll(MyImage image);
        Comment GetById(int id);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
        void SaveChanges();
    }
}
