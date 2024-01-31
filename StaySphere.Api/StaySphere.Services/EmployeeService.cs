using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;

        public EmployeeService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetEmployeeResponse> GetEmployeesAsync(EmployeeResourceParameters employeeResourceParameters)
        {
            var query = _context.Employees.AsQueryable();

            if (employeeResourceParameters.PositionId is not null)
            {
                query = query.Where(x => x.PositionId == employeeResourceParameters.PositionId);
            }

            if (employeeResourceParameters.Salary is not null)
            {
                query = query.Where(x => x.Salary == employeeResourceParameters.Salary);
            }

            if (employeeResourceParameters.SalaryLessThan is not null)
            {
                query = query.Where(x => x.Salary < employeeResourceParameters.SalaryLessThan);
            }

            if (employeeResourceParameters.SalaryGreaterThan is not null)
            {
                query = query.Where(x => x.Salary > employeeResourceParameters.SalaryGreaterThan);
            }

            if (!string.IsNullOrEmpty(employeeResourceParameters.OrderBy))
            {
                query = employeeResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "firstname" => query.OrderBy(x => x.FirstName),
                    "firstnamedesc" => query.OrderByDescending(x => x.FirstName),
                    "lastname" => query.OrderBy(x => x.LastName),
                    "lastnamedesc" => query.OrderByDescending(x => x.LastName),
                    "salary" => query.OrderBy(x => x.Salary),
                    "salarydesc" => query.OrderByDescending(x => x.Salary),
                    "positionid" => query.OrderBy(x => x.PositionId),
                    "positioniddesc" => query.OrderByDescending(x => x.PositionId),
                    _ => query.OrderBy(x => x.FirstName),
                };
            }

            var employees = await query.ToPaginatedListAsync(employeeResourceParameters.PageSize, employeeResourceParameters.PageNumber);
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);

            var paginatedEmployees = new PaginatedList<EmployeeDto>(employeeDtos, employees.TotalCount, employees.CurrentPage, employees.PageSize);

            var result = new GetEmployeeResponse()
            {
                Data = paginatedEmployees.ToList(),
                HasNextPage = paginatedEmployees.HasNext,
                HasPreviousPage = paginatedEmployees.HasPrevious,
                PageNumber = paginatedEmployees.CurrentPage,
                PageSize = paginatedEmployees.PageSize,
                TotalPages = paginatedEmployees.TotalPages
            };

            return result;
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employees = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employees is null)
            {
                throw new EntityNotFoundException($"Entity with id {id} not found!");
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employees);
            return employeeDto;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employeeForCreateDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeForCreateDto);

            _context.Add(employeeEntity);
            await _context.SaveChangesAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeDto;
        }

        public async Task UpdateEmployeeAsync(EmployeeForUpdateDto employeeForUpdateDto)
        {
            var employeeEntity = _mapper.Map<Employee>(employeeForUpdateDto);

            _context.Add(employeeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is not null)
                _context.Remove(employee);

            await _context.SaveChangesAsync();
        }
    }
}
