using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using System.Text.Json;

namespace StaySphere.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync(
              [FromQuery] EmployeeResourceParameters employeeResourceParameters)
        {
            var employees = await _employeeService.GetEmployeesAsync(employeeResourceParameters);

            var metaData = await GetPaginationMetaDataAsync(employees);

            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeeForCreateDto employee)
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EmployeeForUpdateDto employee)
        {
            if (id != employee.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {employee.Id}.");
            }

            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
        private async Task<PagenationMetaData> GetPaginationMetaDataAsync(PaginatedList<EmployeeDto> employeeDtos)
        {
            return new PagenationMetaData
            {
                Totalcount = employeeDtos.TotalCount,
                PageSize = employeeDtos.PageSize,
                CurrentPage = employeeDtos.CurrentPage,
                TotalPages = employeeDtos.TotalPages,
            };
        }
    }
}
