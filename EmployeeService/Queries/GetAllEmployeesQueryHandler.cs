using EmployeeService.DTO;
using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeesQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllEmployees();
            return result;
        }
    }
}
