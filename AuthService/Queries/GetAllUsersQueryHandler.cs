using AuthService.DTO;
using AuthService.Interfaces;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly ICognitoAuthService _cognitoAuthService;

        public GetAllUsersQueryHandler(ICognitoAuthService cognitoAuthService)
        {
            _cognitoAuthService = cognitoAuthService;
        }

        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _cognitoAuthService.GetAllUsersAsync();
            return result;
        }
    }
}
