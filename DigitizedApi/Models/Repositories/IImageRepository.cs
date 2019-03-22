using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitizedApi.Models.Repositories {
    public interface IImageRepository {
        MyImage GetById(int id);
        IEnumerable<MyImage> GetAll();
        void Add(MyImage image);
        void Delete(MyImage image);
        void Update(MyImage image);
        void SaveChanges();
    }
}
