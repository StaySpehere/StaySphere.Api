using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class DocumentResourceParameters : ResourceParametersBase
    {
        public override string OrderBy { get; set; } = "firstName";
    }
}
