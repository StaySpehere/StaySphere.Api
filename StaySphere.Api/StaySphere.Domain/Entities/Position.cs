using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Position : EntityBase
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}