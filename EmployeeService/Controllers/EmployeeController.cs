using System.ComponentModel.DataAnnotations;
using EmployeeService.Commands;
using EmployeeService.DTO;
using EmployeeService.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("All")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var query = new GetAllEmployeesQuery() { };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:required}")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return BadRequest("Id is required");
                var query = new GetEmployeeByIdQuery { Id = id };
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:required}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody][Required] EmployeeDTO body)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return BadRequest("Id is required");
                var command = new UpdateEmployeeCommand { Id = id, Employee = body };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:required}/SoftDelete")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> SoftDeleteEmployee(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return BadRequest("Id is required");
                var command = new SoftDeleteEmployeeCommand { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:required}/HardDelete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> HardDeleteEmployee(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) return BadRequest("Id is required");
                var command = new HardDeleteEmployeeCommand { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("New")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateNewEmployee([FromBody][Required] EmployeeDTO body)
        {
            try
            {
                var command = new CreateNewEmployeeCommand() { Employee = body };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
