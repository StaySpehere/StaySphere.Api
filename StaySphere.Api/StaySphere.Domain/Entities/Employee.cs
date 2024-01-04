using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}