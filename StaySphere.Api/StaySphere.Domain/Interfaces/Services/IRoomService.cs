using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IRoomService
    {
        Task<PaginatedList<RoomDto>> GetRooms(RoomResourceParameters roomResourceParameters);
        Task<RoomDto?> GetRoomById(int id);
        Task<RoomDto> CreateRoom(RoomForCreateDto roomForCreateDto);
        Task UpdateRoom(RoomForUpdateDto roomForUpdateDto);
        Task DeleteRoom(int id);
    }
}
