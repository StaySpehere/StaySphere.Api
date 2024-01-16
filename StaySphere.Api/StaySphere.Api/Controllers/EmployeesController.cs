using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Interfaces.Services;
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
        public ActionResult<IEnumerable<EmployeeDto>> GetEmployeesAsync(
              [FromQuery] EmployeeResourceParameters employeeResourceParameters)
        {
            var employees = _employeeService.GetEmployees(employeeResourceParameters);

            return Ok(employees);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeDto> Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmployeeForCreateDto employee)
        {
            _employeeService.CreateEmployee(employee);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, EmployeeForUpdateDto employee)
        {
            if (id != employee.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {employee.Id}.");
            }
            _employeeService.UpdateEmployee(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);

            return NoContent();
        }
    }
}
