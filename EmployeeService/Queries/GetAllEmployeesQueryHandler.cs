using EmployeeService.DTO;
using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public GetAllEmployeesQueryHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAllEmployees();
            return result;

            // Execute SP
            //var result = await _employeeRawService.GetAllEmployeesAsync(false);
            //return result;
        }
    }
}
