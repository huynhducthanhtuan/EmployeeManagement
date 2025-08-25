using AuthService.DTO;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDTO>>
    {
    }
}
