using StaySphere.Domain.DTOs.Employee;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployees();
        EmployeeDto? GetEmployeeById(int id);
        EmployeeDto CreateEmployee(EmployeeForCreateDto employeeForCreateDto);
        void UpdateEmployee(EmployeeForUpdateDto employeeForUpdateDto);
        void DeleteEmployee(int id);
    }
}
