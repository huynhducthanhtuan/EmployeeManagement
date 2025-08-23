using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class CreateNewEmployeeCommandHandler : IRequestHandler<CreateNewEmployeeCommand, bool>
    {
        private readonly IEmployeeService _employeeService;

        public CreateNewEmployeeCommandHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<bool> Handle(CreateNewEmployeeCommand request, CancellationToken cancellationToken)
        {
            var result = await _employeeService.CreateNewEmployee(request);
            return result;
        }
    }
}
