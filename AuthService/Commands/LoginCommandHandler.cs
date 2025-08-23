using AuthService.DTO;
using AuthService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly ICognitoAuthService _cognitoAuthService;

        public LoginCommandHandler(ICognitoAuthService cognitoAuthService)
        {
            _cognitoAuthService = cognitoAuthService;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _cognitoAuthService.LoginAsync(request.LoginRequest, cancellationToken);
            return result;
        }
    }
}
