using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Employee : EntityBase
    {
        public int PositionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public Position Position { get; set; }
    }
}
