using EmployeeService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public UpdateEmployeeDTO Employee { get; set; }
    }
}
