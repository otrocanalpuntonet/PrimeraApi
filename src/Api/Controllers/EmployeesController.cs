using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Dto;
using Api.Services;
using Api.Parametros;
using MediatR;
using Api.Feautures.GetEmployees;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    private readonly IMediator _mediator;

    public EmployeesController(
        IEmployeeService service,
        IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }

    // GET: api/Employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees
        ([FromQuery] RequestParameters parameters)
    {
        var employees = await _mediator.Send(new GetEmployeeRequest(parameters));
        //var employees = await _service.GetAllAsync(parameters);
        return Ok(employees);
    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(Guid id)
    {
        var employee = await _service.GetEmployee(id);

        return Ok(employee);
    }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(Guid id, UpdateEmployeeDto employee)
    {
        await _service.UpdateEmployee(id, employee);
    
        return NoContent();
    }

    // POST: api/Employees
    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee([FromForm] CreateEmployeeDto employee)
    {
        var createEmployee = await _service.AddEmployee(employee);
  
        return CreatedAtAction("GetEmployee", new { id = createEmployee.Id }, createEmployee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        await _service.DeleteEmployee(id);

        return NoContent();
    }
}
