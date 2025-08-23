using EmployeeService.DTO;
using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetEmployeeById(request);
            return result;
        }
    }
}
