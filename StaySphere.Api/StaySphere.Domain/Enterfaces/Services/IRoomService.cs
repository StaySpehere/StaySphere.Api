using StaySphere.Domain.DTOs.Room;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IRoomService
    {
        Task<RoomDto> GetRooms();
        Task<RoomDto?> GetRoomById(int id);
        Task<RoomDto> CreateRoom(RoomForCreateDto roomForCreateDto);
        Task UpdateRoom(RoomForUpdateDto roomForUpdateDto);
        Task DeleteRoom(int id);
    }
}
