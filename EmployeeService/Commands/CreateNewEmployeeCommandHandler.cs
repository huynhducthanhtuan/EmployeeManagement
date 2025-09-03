using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRawService _employeeRawService;

        public CreateNewEmployeeCommandHandler(IEmployeeService employeeService, IEmployeeRawService employeeRawService)
        {
            _employeeService = employeeService;
            _employeeRawService = employeeRawService;
        }

        public async Task<bool> Handle(CreateNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.CreateNewEmployee(request);
            return result;

            // Execute SP
            //var result = await _employeeRawService.AddEmployeeAsync(request.Employee);
            //return true;
        }
    }
}
