using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.UpdateEmployee(request);
            return result;

            // Execute SP
            //var result = await _employeeRawService.UpdateEmployeeAsync(request.Id, request.Employee);
            //return true;
        }
    }
}
