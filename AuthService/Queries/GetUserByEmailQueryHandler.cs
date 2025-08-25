using AuthService.DTO;
using AuthService.Interfaces;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        private readonly ICognitoAuthService _cognitoAuthService;

        public GetUserByEmailQueryHandler(ICognitoAuthService cognitoAuthService)
        {
            _cognitoAuthService = cognitoAuthService;
        }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _cognitoAuthService.GetUserByEmailAsync(request.Email);
            return result;
        }
    }
}
