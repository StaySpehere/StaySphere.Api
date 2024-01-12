using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.DTOs.Review;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
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

        public async Task<PaginatedList<RoomDto>> GetRooms(RoomResourceParameters roomResourceParameters)
        {
            var query = _context.Rooms.AsQueryable();

            if (roomResourceParameters.CategoryId is not null)
            {
                query = query.Where(x => x.CategoryId == roomResourceParameters.CategoryId);
            }

            if (!string.IsNullOrEmpty(roomResourceParameters.OrderBy))
            {
                query = roomResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "Number" => query.OrderBy(x => x.Number),
                    "Numberdesc" => query.OrderByDescending(x => x.Number),
                    "Floor" => query.OrderBy(x => x.Floor),
                    "Floordesc" => query.OrderByDescending(x => x.Floor),
                    "categoryId" => query.OrderBy(x => x.CategoryId),
                    "categoryIddesc" => query.OrderByDescending(x => x.CategoryId),
                    _ => query.OrderBy(x => x.Floor)
                };
            }

            var rooms = await query.ToPaginatedListAsync(roomResourceParameters.PageSize, roomResourceParameters.PageNumber);
            var roomDtos = _mapper.Map<List<RoomDto>>(rooms);

            return new PaginatedList<RoomDto>(roomDtos, rooms.TotalCount, rooms.CurrentPage, rooms.PageSize);

        }
    }
}
