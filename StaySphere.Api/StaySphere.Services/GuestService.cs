using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class GuestService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<GuestService> _logger;

        public GuestService(IMapper mapper, StaySphereDbContext context, ILogger<GuestService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
