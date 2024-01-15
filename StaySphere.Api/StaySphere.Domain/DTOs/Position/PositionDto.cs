using StaySphere.Domain.DTOs.Employee;

namespace StaySphere.Domain.DTOs.Position
{
    public record PositionDto(
        int Id,
        string Name,
        decimal Salary,
        ICollection<EmployeeDto> Employees);
}
