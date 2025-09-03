namespace EmployeeService.Interfaces
{
    public interface ISqlRawRepository
    {
        Task<List<T>> ExecuteStoredProcedureGetAsync<T>(string sql, params object[] parameters) where T : class;
        Task<int> ExecuteStoredProcedureNonQueryAsync(string sql, params object[] parameters);
    }
}
