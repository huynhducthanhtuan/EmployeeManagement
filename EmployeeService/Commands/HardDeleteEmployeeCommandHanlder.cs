using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class HardDeleteEmployeeCommandHandler : IRequestHandler<HardDeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;

        public HardDeleteEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Handle(HardDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.HardDeleteEmployee(request);
            return result;
        }
    }
}
