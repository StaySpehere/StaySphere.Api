using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(EmployeeResourceParameters employeeResourceParameters);
        Task<EmployeeDto?> GetEmployeeById(int id);
        Task<EmployeeDto> CreateEmployee(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateEmployee(EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteEmployee(int id);
    }
}
