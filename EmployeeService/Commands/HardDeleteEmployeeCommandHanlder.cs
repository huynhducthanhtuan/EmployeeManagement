using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class HardDeleteEmployeeCommandHandler : IRequestHandler<HardDeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public HardDeleteEmployeeCommandHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<bool> Handle(HardDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.HardDeleteEmployee(request);
            return result;

            // Execute SP
            //var result = await _employeeRawService.HardDeleteEmployeeAsync(request.Id);
            //return true;
        }
    }
}
