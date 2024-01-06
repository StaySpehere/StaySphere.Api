using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
