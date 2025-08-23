using EmployeeService.Commands;
using EmployeeService.DTO;
using EmployeeService.Queries;

namespace EmployeeService.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO> GetEmployeeById(GetEmployeeByIdQuery request);
        Task<bool> CreateNewEmployee(CreateNewEmployeeCommand request);
        Task<bool> UpdateEmployee(UpdateEmployeeCommand request);
        Task<bool> SoftDeleteEmployee(SoftDeleteEmployeeCommand request);
        Task<bool> HardDeleteEmployee(HardDeleteEmployeeCommand request);
    }
}
