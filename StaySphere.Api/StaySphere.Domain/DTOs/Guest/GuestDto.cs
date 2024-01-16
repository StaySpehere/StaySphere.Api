using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.DTOs.Guest
{
    public record GuestDto(
        int Id,
        int DocumentId,
        int PhoneNumber,
        string Email,
        ICollection<BookingDto> Bookings);
}
