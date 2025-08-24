using AuthService.DTO;
using MediatR;

namespace EmployeeService.Commands
{
    public class ConfirmRegisterCommand : IRequest<bool>
    {
        public RegisterConfirmation RegisterConfirmation { get; set; }
    }
}
