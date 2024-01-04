using StaySphere.Domain.Common;

namespace StaySphere.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);  
    }
}
