using StaySphere.Domain.DTOs.Employee;

namespace StaySphere.Domain.DTOs.Position
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}
