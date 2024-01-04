using StaySphere.Domain.Enterfaces.Repositories;
using StaySphere.Domain.Entities;

namespace StaySphere.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(StaySphereDbContext dbContext) : base(dbContext) { }
    }
}
