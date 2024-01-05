using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
