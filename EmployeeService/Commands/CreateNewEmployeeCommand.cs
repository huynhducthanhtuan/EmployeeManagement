using EmployeeService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class CreateNewEmployeeCommand : IRequest<bool>
    {
        public EmployeeDTO Employee { get; set; }
    }
}
