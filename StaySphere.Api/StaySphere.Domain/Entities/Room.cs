using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Room : EntityBase
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}