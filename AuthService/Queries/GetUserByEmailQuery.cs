using AuthService.DTO;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
    }
}
