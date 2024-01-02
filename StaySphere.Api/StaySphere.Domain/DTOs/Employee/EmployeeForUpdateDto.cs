namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeForUpdateDto(
        int Id,
        string FirstName,
        int PositionId,
        decimal Salary);
}
