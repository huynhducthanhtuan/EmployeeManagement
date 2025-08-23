using AuthService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class RegisterCommand : IRequest<bool>
    {
        public RegisterRequest RegisterRequest { get; set; }
    }
}
