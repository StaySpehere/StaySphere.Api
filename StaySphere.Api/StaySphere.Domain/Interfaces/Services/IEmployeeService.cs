using StaySphere.Domain.DTOs.Employee;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployees();
        Task<EmployeeDto?> GetEmployeeById(int id);
        Task<EmployeeDto> CreateEmployee(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateEmployee(EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteEmployee(int id);
    }
}
