using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using united_movers_api.Models;
using united_movers_api.Services.Interfaces;

namespace united_movers_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetActiveEmployeesAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeId = await _employeeService.InsertEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeId }, employee);
        }


        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeID)
            {
                return BadRequest("Employee ID mismatch");
            }

            var result = await _employeeService.UpdateEmployeeAsync(employee);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
