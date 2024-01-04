using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(StaySphereDbContext context) : base(context) { }
    }
}
