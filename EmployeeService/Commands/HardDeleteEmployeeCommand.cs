using MediatR;

namespace EmployeeService.Commands
{
    public class HardDeleteEmployeeCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
