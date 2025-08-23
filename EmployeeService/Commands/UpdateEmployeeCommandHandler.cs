using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;

        public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.UpdateEmployee(request);
            return result;
        }
    }
}
