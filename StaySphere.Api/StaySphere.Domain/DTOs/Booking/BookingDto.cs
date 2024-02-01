using StaySphere.Domain.DTOs.Review;

namespace StaySphere.Domain.DTOs.Booking
{
    public record BookingDto(
        int Id,
        int GuestId,
        int EmployeeId,
        int RoomId,
        int StayDuration,
        decimal TotalPrice,
        ICollection<ReviewDto> Reviews);
}