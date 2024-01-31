using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<GetEmployeeResponse> GetEmployeesAsync(EmployeeResourceParameters employeeResourceParameters);
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employeeForCreateDto);
        Task UpdateEmployeeAsync(EmployeeForUpdateDto employeeForUpdateDto);
        Task DeleteEmployeeAsync(int id);
    }
}
