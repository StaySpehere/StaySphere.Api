using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Common;
using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Exeptions;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly StaySphereDbContext _context;
        public RepositoryBase(StaySphereDbContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            var createEntity = await _context.Set<T>().AddAsync(entity);

            return createEntity.Entity;
        }

        public async Task Delete(int id)
        {
            var entity = await FindById(id);

            if (entity is null)
            {
                throw new EntityNotFoundException(
                    $"Entity {typeof(T)} with id: {id} not found.");
            }

            _context.Set<T>().Remove(entity);
        }

        public async Task<T> FindById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity is null)
            {
                throw new EntityNotFoundException(
                    $"Entity {typeof(T)} with id: {id} not found.");
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities =await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
