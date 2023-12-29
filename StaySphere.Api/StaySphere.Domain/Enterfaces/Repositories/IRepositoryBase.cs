using StaySphere.Domain.Common;

namespace StaySphere.Domain.Enterfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);  
    }
}
