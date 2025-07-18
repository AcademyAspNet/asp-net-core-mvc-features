using WebApplication7.Data.Models;

namespace WebApplication7.Data.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IList<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
    }
}
