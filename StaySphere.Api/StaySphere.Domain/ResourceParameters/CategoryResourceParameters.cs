using StaySphere.Domain.Resource;

namespace StaySphere.Domain.ResourceParameters
{
    public class CategoryResourceParameters : ResourceParametersBase
    {
        public string OrderBy { get; set; } = "name";
        public decimal? Price { get; set; }
        public decimal? PriceLessThan { get; set; }
        public decimal? PriceGreaterThan { get; set; }

    }
}
