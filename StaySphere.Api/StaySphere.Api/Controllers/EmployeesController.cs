using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaySphere.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> Get()
        {
            var employees = _employeeService.GetEmployees();

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
