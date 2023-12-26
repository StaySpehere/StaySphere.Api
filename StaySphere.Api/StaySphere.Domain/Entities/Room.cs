using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Room : EntityBase
    {
        public int CategoryId { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public Category Category { get; set; }
    }
}
