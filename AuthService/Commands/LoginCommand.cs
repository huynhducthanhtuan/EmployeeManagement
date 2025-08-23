using AuthService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class LoginCommand : IRequest<AuthResponse>
    {
        public LoginRequest LoginRequest { get; set; }
    }
}
