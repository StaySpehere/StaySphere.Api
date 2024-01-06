using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Booking : EntityBase
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int GuestId { get; set; }
        public Guest Guest { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}