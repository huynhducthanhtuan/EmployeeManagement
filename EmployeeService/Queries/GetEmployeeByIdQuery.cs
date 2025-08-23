using EmployeeService.DTO;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDTO>
    {
        public string Id { get; set; }
    }
}
