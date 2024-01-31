using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
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

        public RoomService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedList<RoomDto>> GetRoomsAsync(RoomResourceParameters roomResourceParameters)
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
                    "number" => query.OrderBy(x => x.Number),
                    "numberdesc" => query.OrderByDescending(x => x.Number),
                    "floor" => query.OrderBy(x => x.Floor),
                    "floordesc" => query.OrderByDescending(x => x.Floor),
                    "categoryid" => query.OrderBy(x => x.CategoryId),
                    "categoryiddesc" => query.OrderByDescending(x => x.CategoryId),
                    _ => query.OrderBy(x => x.Floor)
                };
            }

            var rooms = await query.ToPaginatedListAsync(roomResourceParameters.PageSize, roomResourceParameters.PageNumber);
            var roomDtos = _mapper.Map<List<RoomDto>>(rooms);

            return new PaginatedList<RoomDto>(roomDtos, rooms.TotalCount, rooms.CurrentPage, rooms.PageSize);
        }

        public async Task<RoomDto?> GetRoomByIdAsync(int id)
        {
            var rooms = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (rooms is null)
            {
                throw new EntityNotFoundException($"Room with id {id} not found!");
            }

            var roomDtos = _mapper.Map<RoomDto>(rooms);
            return roomDtos;
        }

        public async Task<RoomDto> CreateRoomAsync(RoomForCreateDto roomForCreateDto)
        {
            var roomEntity = _mapper.Map<Room>(roomForCreateDto);

            _context.Add(roomEntity);
            await _context.SaveChangesAsync();

            var roomDto = _mapper.Map<RoomDto>(roomEntity);
            return roomDto;
        }

        public async Task UpdateRoomAsync(RoomForUpdateDto roomForUpdateDto)
        {
            var roomEntity = _mapper.Map<Room>(roomForUpdateDto);

            _context.Add(roomEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room is not null)
                _context.Remove(room);

            await _context.SaveChangesAsync();
        }
    }
}
