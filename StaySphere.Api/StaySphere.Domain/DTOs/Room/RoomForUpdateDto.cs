namespace StaySphere.Domain.DTOs.Room
{
    public record RoomForUpdateDto(
        int Id,
        int CategoryId,
        int Number,
        int Floor);
}
