using StaySphere.Domain.DTOs.Room;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IRoomService
    {
        RoomDto GetRooms();
        RoomDto? GetRoomById(int id);
        RoomDto CreateRoom(RoomForCreateDto roomForCreateDto);
        void UpdateRoom(RoomForUpdateDto roomForUpdateDto);
        void DeleteRoom(int id);
    }
}
