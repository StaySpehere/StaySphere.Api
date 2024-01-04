using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class GuestResourceParameters : ResourceParametersBase
    {
        public int DocumentId { get; set; }
        public override int MaxPageSize { get; set; } = 30;
    }
}
