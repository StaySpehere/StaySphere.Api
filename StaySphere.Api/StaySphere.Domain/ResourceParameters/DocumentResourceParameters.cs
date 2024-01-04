using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class DocumentResourceParameters : ResourceParametersBase
    {
        public string OrderBy { get; set; } = "firstName";
    }
}
