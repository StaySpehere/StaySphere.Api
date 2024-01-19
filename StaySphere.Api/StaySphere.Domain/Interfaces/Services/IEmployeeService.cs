using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<PaginatedList<EmployeeDto>> GetEmployeesAsync(EmployeeResourceParameters employeeResourceParameters);
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateEmployeeAsync(EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteEmployee(int id);
    }
}
