using EmployeeService.DTO;
using EmployeeService.Interfaces;
using EmployeeService.Services;
using MediatR;

namespace EmployeeService.Queries
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public GetEmployeeByIdQueryHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetEmployeeById(request);
            return result;

            // Execute SP
            //var result = await _employeeRawService.GetEmployeeByIdAsync(request.Id);
            //return result;
        }
    }
}
