using EmployeeService.DTO;
using EmployeeService.Interfaces;

namespace EmployeeService.Services
{
    public class EmployeeRawService : IEmployeeRawService
    {
        private readonly ISqlRawRepository _sqlRawRepository;

        public EmployeeRawService(ISqlRawRepository sqlRawRepository)
        {
            _sqlRawRepository = sqlRawRepository;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(string employeeId)
        {
            var result =  await _sqlRawRepository.ExecuteStoredProcedureGetAsync<EmployeeDTO>(
                "EXEC [dbo].[sp_GetEmployeeById] @EmployeeId={0}",
                employeeId
            );
            return result?.FirstOrDefault();
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(bool includeDeleted = false)
        {
            var result = await _sqlRawRepository.ExecuteStoredProcedureGetAsync<EmployeeDTO>(
                "EXEC [dbo].[sp_GetAllEmployees] @IncludeDeleted={0}",
                includeDeleted ? 1 : 0
            );
            return result;
        }

        public async Task<int> AddEmployeeAsync(AddEmployeeDTO entity)
        {
            var result = await _sqlRawRepository.ExecuteStoredProcedureNonQueryAsync(
                "EXEC [dbo].[sp_AddEmployee] @FullName={0}, @Gender={1}, @DateOfBirth={2}, @Hometown={3}, @AvatarImage={4}, @PositionId={5}, @DepartmentId={6}",
                entity.FullName,
                entity.Gender,
                entity.DateOfBirth,
                entity.Hometown,
                entity.AvatarImage,
                entity.PositionId,
                entity.DepartmentId
            );
            return result;
        }

        public async Task<int> UpdateEmployeeAsync(string employeeId, UpdateEmployeeDTO entity)
        {
            var result = await _sqlRawRepository.ExecuteStoredProcedureNonQueryAsync(
                "EXEC [dbo].[sp_UpdateEmployee] @EmployeeId={0}, @FullName={1}, @Gender={2}, @DateOfBirth={3}, @Hometown={4}, @AvatarImage={5}",
                employeeId,
                entity.FullName,
                entity.Gender,
                entity.DateOfBirth,
                entity.Hometown,
                entity.AvatarImage
            );
            return result;
        }

        public async Task<int> SoftDeleteEmployeeAsync(string employeeId)
        {
            var result = await _sqlRawRepository.ExecuteStoredProcedureNonQueryAsync(
                "EXEC [dbo].[sp_SoftDeleteEmployee] @EmployeeId={0}",
                employeeId
            );
            return result;
        }

        public async Task<int> HardDeleteEmployeeAsync(string employeeId)
        {
            var result = await _sqlRawRepository.ExecuteStoredProcedureNonQueryAsync(
                "EXEC [dbo].[sp_HardDeleteEmployee] @EmployeeId={0}",
                employeeId
            );
            return result;
        }
    }
}
