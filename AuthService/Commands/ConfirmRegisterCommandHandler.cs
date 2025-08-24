using AuthService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class ConfirmRegisterCommandHandler : IRequestHandler<ConfirmRegisterCommand, bool>
    {
        private readonly ICognitoAuthService _cognitoAuthService;

        public ConfirmRegisterCommandHandler(ICognitoAuthService cognitoAuthService)
        {
            _cognitoAuthService = cognitoAuthService;
        }

        public async Task<bool> Handle(ConfirmRegisterCommand request, CancellationToken cancellationToken)
        {
            await _cognitoAuthService.ConfirmRegisterAsync(request.RegisterConfirmation, cancellationToken);
            return true;
        }
    }
}
