using API.Backend.Services.Employees;
using API.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/<EmployeesController>
        private readonly IEmployeeService _employeeSC;
        public EmployeesController(IEmployeeService employeeSC)
        {
            _employeeSC = employeeSC;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allEmployees = _employeeSC.GetAllEmployees();
            return Ok(allEmployees);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var employeeAdded = _employeeSC.AddEmployee(employee);
            return Ok(employeeAdded);
        }


        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _employeeSC.DeleteEmployee(id);
            return Ok();
        }
    }
}
