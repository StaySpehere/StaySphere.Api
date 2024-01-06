using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class ReviewResourceParameters : ResourceParametersBase
    {
        public decimal Grade { get; set; }
        public override string OrderBy { get; set; }
        public int BookingId { get; set; }
        public decimal? GradeLessThan { get; set; }
        public decimal? GradeGreaterThan { get; set; }
    }
}
