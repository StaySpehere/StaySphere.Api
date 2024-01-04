using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class GuestRepository : RepositoryBase<Guest>, IGuestRepository
    {
        public GuestRepository(StaySphereDbContext context) : base(context) { }
    }
}
