using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
