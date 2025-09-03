using EmployeeService.Interfaces;
using EmployeeService.Services;
using MediatR;

namespace EmployeeService.Commands
{
    public class SoftDeleteEmployeeCommandHandler : IRequestHandler<SoftDeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public SoftDeleteEmployeeCommandHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<bool> Handle(SoftDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.SoftDeleteEmployee(request);
            return result;

            // Execute SP
            //var result = await _employeeRawService.SoftDeleteEmployeeAsync(request.Id);
            //return true;
        }
    }
}
