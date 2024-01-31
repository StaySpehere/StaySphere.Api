using StaySphere.Domain.DTOs.Room;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IRoomService
    {
        Task<GetRoomResponse> GetRoomsAsync(RoomResourceParameters roomResourceParameters);
        Task<RoomDto?> GetRoomByIdAsync(int id);
        Task<RoomDto> CreateRoomAsync(RoomForCreateDto roomForCreateDto);
        Task UpdateRoomAsync(RoomForUpdateDto roomForUpdateDto);
        Task DeleteRoomAsync(int id);
    }
}
