namespace DigitizedApi.Models.Repositories {
    public interface IVisitorRepository {
        Visitor GetBy(string email);
        void AddVisitor(Visitor visitor);
        void SaveChanges();
    }
}
