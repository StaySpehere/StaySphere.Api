using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Review : EntityBase
    {
        public int BookingId { get; set; }
        public string Comment { get; set;}
        public string Grade { get; set; }
        public Booking Booking { get; set; }
    }
}
