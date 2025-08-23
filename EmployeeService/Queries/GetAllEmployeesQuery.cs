using EmployeeService.DTO;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeDTO>>
    {
    }
}
