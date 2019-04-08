using System.Collections.Generic;

namespace DigitizedApi.Models.Repositories {
    public interface IVisitorRepository {
        Visitor GetBy(string email);
        void AddVisitor(Visitor visitor);
        void SaveChanges();

        IEnumerable<Visitor> GetAll();
    }
}
