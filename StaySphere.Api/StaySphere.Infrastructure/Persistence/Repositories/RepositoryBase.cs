using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.Common;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly StaySphereDbContext _context;
        public RepositoryBase(StaySphereDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }
        public async Task<T> FindByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity is null)
            {
                throw new EntityNotFoundException(
                    $"Entity {typeof(T)} with id: {id} not found.");
            }

            return entity;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var createEntity = await _context.Set<T>().AddAsync(entity);

            return createEntity.Entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity is null)
            {
                throw new EntityNotFoundException(
                    $"Entity {typeof(T)} with id: {id} not found.");
            }
            _context.Set<T>().Remove(entity);
        }
    }
}
