using System.Collections.Generic;

namespace DigitizedApi.Models.Repositories {
    public interface IVideoRepository {
        MyVideo GetById(int id);
        IEnumerable<MyVideo> GetAll();
        void Add(MyVideo image);
        void Delete(MyVideo image);
        void Update(MyVideo image);
        void SaveChanges();
    }
}
