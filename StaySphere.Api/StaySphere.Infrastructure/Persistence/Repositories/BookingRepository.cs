using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(StaySphereDbContext context) : base(context) { }
    }
}
