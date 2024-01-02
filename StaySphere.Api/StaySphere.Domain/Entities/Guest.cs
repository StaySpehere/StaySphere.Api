using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Guest : EntityBase
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}