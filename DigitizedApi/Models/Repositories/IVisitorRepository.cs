using System.Collections.Generic;

namespace DigitizedApi.Models.Repositories {
    public interface IVisitorRepository {
        IEnumerable<Visitor> GetAll();
        Visitor GetById(string email);
        void AddVisitor(Visitor visitor);
        void SaveChanges();

    }
}
