using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.Interfaces.Repositories;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class PositionService : IPositionService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<PositionService> _logger;

        public PositionService(IMapper mapper, StaySphereDbContext context, ILogger<PositionService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
