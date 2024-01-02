namespace StaySphere.Domain.DTOs.Booking
{
    public record BookingForUpdateDto(
        int Id,
        int GuestId,
        int EmployeeId,
        int RoomId);   
}
