using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.Interfaces.Repositories;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class RoomService : IRoomService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<RoomService> _logger;

        public RoomService(IMapper mapper, StaySphereDbContext context, ILogger<RoomService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
