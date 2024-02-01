using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class GuestResourceParameters : ResourceParametersBase
    {
        public int? DocumentId { get; set; }
        public override string OrderBy { get; set; } = "Email";
        public override int MaxPageSize { get; set; } = 30;
    }
}
