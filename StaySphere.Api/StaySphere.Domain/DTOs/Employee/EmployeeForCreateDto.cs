namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeForCreateDto(
        string Name,
        int PositionId,
        decimal Salary);

}
