using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class BookingResourceParameters : ResourceParametersBase
    {
        public int? GuestId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoomId { get; set; }
        public override string OrderBy { get; set;}
        public decimal? TotalPrice { get; set; }
        public decimal? TotalPriceLessThan { get; set; }
        public decimal? TotalPriceGreaterThan { get; set; }
    }
}
