using AuthService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly ICognitoAuthService _cognitoAuthService;

        public RegisterCommandHandler(ICognitoAuthService cognitoAuthService)
        {
            _cognitoAuthService = cognitoAuthService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _cognitoAuthService.RegisterAsync(request.RegisterRequest, cancellationToken);
            return true;
        }
    }
}
