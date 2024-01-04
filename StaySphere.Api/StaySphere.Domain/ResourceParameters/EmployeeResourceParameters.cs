using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class EmployeeResourceParameters : ResourceParametersBase
    {
        public int PositionId { get; set; }
        public override string OrderBy { get; set; } = "firstName";
        public decimal? Salary { get; set; }
        public decimal? SalaryLessThan { get; set; }
        public decimal? SalaryGreaterThan { get; set; }
    }
}
