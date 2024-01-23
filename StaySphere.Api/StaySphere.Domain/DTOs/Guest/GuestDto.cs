using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.DTOs.Guest
{
    public record GuestDto(
        int Id,
        int DocumentId,
        string PhoneNumber,
        string Email,
        ICollection<BookingDto> Bookings);
}
