using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Repositories;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
