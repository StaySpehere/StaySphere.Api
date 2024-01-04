using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class BookingResourceParameters : ResourceParametersBase
    {
        public decimal TotalPrice { get; set; }
        public int GuestId { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public decimal? PriceLessThan { get; set; }
        public decimal? PriceGreaterThan { get; set; }
    }
}
