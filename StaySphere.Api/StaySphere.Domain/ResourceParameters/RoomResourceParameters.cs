using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class RoomResourceParameters : ResourceParametersBase
    {
        public int? CategoryId { get; set; }
        public override string OrderBy { get; set; }
    }
}
