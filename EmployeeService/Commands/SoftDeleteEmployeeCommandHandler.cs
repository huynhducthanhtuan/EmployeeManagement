using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class SoftDeleteEmployeeCommandHandler : IRequestHandler<SoftDeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;

        public SoftDeleteEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Handle(SoftDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.SoftDeleteEmployee(request);
            return result;
        }
    }
}
