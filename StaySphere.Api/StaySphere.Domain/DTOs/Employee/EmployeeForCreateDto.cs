namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeForCreateDto(
        string FirstName,
        int PositionId,
        decimal Salary);
}
