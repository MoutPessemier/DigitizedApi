using System.Collections.Generic;

namespace DigitizedApi.Models.Repositories {
    public interface IImageRepository {
        MyImage GetById(int id);
        IEnumerable<MyImage> GetAll();
        void Add(MyImage image);
        void SaveChanges();
        IEnumerable<Comment> GetComments(int id);
        MyImage GetByIdNoTracking(int id);
    }
}
