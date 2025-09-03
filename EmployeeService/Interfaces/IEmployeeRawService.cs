using EmployeeService.DTO;

namespace EmployeeService.Interfaces
{
    public interface IEmployeeRawService
    {
        Task<EmployeeDTO> GetEmployeeByIdAsync(string employeeId);
        Task<List<EmployeeDTO>> GetAllEmployeesAsync(bool includeDeleted = false);
        Task<int> AddEmployeeAsync(AddEmployeeDTO entity);
        Task<int> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDTO entity);
        Task<int> SoftDeleteEmployeeAsync(string employeeId);
        Task<int> HardDeleteEmployeeAsync(string employeeId);
    }
}
