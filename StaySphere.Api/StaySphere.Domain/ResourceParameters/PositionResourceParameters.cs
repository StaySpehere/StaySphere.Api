using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class PositionResourceParameters : ResourceParametersBase
    {
        public string OrderBy { get; set; } = "name";
        public decimal? Salary { get; set; }
        public decimal? SalaryLessThan { get; set; }
        public decimal? SalaryGreaterThan { get; set; }
        public override int MaxPageSize { get; set; } = 30;
    }
}
