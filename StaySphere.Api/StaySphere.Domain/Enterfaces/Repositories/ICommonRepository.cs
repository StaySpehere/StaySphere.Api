
namespace StaySphere.Domain.Enterfaces.Repositories
{
    public interface ICommonRepository
    {
        public IBookingRepository Booking {  get; }
        public ICategoryRepository Category { get; }
        public IDocumentRepository Document { get; }
        public IEmployeeRepository Employee { get; }
        public IGuestRepository Guest { get; }
        public IPositionRepository Position { get; }
        public IReviewRepository Review { get; }
        public IRoomRepository Room { get; }
        public Task<int> SaveChangesAsync();
    }
}
