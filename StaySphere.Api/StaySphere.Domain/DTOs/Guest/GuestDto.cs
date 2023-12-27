using StaySphere.Domain.DTOs.Booking;

namespace StaySphere.Domain.DTOs.Guest
{
    public class GuestDto
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<BookingDto> Bookings { get; set; }
    }
}
