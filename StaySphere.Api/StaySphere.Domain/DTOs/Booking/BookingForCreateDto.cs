namespace StaySphere.Domain.DTOs.Booking
{
    public record BookingForCreateDto(
        int GuestId,
        int EmployeeId,
        int RoomId);
}
