using MediatR;

namespace EmployeeService.Commands
{
    public class SoftDeleteEmployeeCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
