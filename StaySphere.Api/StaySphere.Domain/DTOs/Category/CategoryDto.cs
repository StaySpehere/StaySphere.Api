using StaySphere.Domain.DTOs.Room;

namespace StaySphere.Domain.DTOs.Category
{
    public record CategoryDto(
        int Id,
        string Name,
        decimal Price,
        int NumberOfRooms,
    ICollection<RoomDto> Rooms);
}
