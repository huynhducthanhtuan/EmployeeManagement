using EmployeeService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class CreateNewEmployeeCommand : IRequest<bool>
    {
        public AddEmployeeDTO Employee { get; set; }
    }
}
