using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaySphere.Domain.DTOs.Booking;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

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
            var metaData = await GetPagenationMetaDataAsync(employees);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

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
        private async Task<PagenationMetaData> GetPagenationMetaDataAsync(PaginatedList<EmployeeDto> employeeDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = employeeDtOs.TotalCount,
                PageSize = employeeDtOs.PageSize,
                CurrentPage = employeeDtOs.CurrentPage,
                TotalPages = employeeDtOs.TotalPages,
            };
        }
        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
