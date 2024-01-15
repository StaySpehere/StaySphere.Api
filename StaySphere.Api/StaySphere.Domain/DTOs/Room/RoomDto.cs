using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.DTOs.Room
{
    public record RoomDto(
        int Id,
        int CategoryId,
        int  Number,
        int Floor,
        ICollection<BookingDto> Bookings);
}
