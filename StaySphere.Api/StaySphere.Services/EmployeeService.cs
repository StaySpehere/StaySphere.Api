using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IMapper mapper, StaySphereDbContext context, ILogger<EmployeeService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
    }
}
