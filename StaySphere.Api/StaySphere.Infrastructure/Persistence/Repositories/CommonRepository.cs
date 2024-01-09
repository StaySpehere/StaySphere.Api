using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly StaySphereDbContext _context;

        public IBookingRepository _booking;
        public IBookingRepository Booking
        {
            get
            {
                _booking ??= new BookingRepository(_context);
                return _booking;
            }
        }

        public ICategoryRepository _category;
        public ICategoryRepository Category
        {
            get
            {
                _category ??= new CategoryRepository(_context);
                return _category;
            }
        }

        public IDocumentRepository _document;
        public IDocumentRepository Document
        {
            get
            {
                _document ??= new DocumentRepository(_context);
                return _document;
            }
        }
        public IEmployeeRepository _employee;
        public IEmployeeRepository Employee
        {
            get
            {
                _employee ??= new EmployeeRepository(_context);
                return _employee;
            }
        }
        public IGuestRepository _guest;
        public IGuestRepository Guest
        {
            get
            {
                _guest ??= new GuestRepository(_context);
                return _guest;
            }
        }
        public IPositionRepository _position;
        public IPositionRepository Position
        {
            get
            {
                _position ??= new PositionRepository(_context);
                return _position;
            }
        }
        public IReviewRepository _review;
        public IReviewRepository Review
        {
            get
            {
                _review ??= new ReviewRepository(_context);
                return _review;
            }
        }
        public IRoomRepository _room;
        public IRoomRepository Room
        {
            get
            {
                _room ??= new RoomRepository(_context);
                return _room;
            }
        }
        public CommonRepository(StaySphereDbContext context)
        {
            _context = context;
            _booking = new BookingRepository(context);
            _category = new CategoryRepository(context);
            _document = new DocumentRepository(context);
            _employee = new EmployeeRepository(context);
            _position = new PositionRepository(context);
            _guest = new GuestRepository(context);
            _review = new ReviewRepository(context);
            _room = new RoomRepository(context);
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
