using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
