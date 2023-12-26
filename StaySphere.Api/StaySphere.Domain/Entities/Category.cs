using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
