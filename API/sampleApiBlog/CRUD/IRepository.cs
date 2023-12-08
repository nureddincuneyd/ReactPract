using sampleApiBlog.Models;

namespace sampleApiBlog.CRUD
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetByPk(long id);
        T Add(T entity);
        T Update(T entity);
        T Remove(long id);
    }
}
