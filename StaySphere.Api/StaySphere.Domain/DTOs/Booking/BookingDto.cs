using StaySphere.Domain.DTOs.Review;

namespace StaySphere.Domain.DTOs.Booking
{
    public class BookingDto
    {
        public int Id { get; set; }

        public int GuestId { get; set; }

        public int EmployeeId { get; set; }

        public int RoomId { get; set; }

        public DateTime StayDuration { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
