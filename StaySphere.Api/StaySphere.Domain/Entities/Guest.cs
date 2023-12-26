using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Guest : EntityBase
    {
        public int DocumentId { get; set; }
        public int PhoneNumber  { get; set; }
        public string Email { get; set; }
        public Document Document { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}