using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IRoomService
    {
        Task<PaginatedList<RoomDto>> GetRoomsAsync(RoomResourceParameters roomResourceParameters);
        Task<RoomDto?> GetRoomByIdAsync(int id);
        Task<RoomDto> CreateRoomAsync(RoomForCreateDto roomForCreateDto);
        Task UpdateRoomAsync(RoomForUpdateDto roomForUpdateDto);
        Task DeleteRoomAsync(int id);
    }
}
