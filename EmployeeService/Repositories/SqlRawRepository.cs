using EmployeeService.Interfaces;
using Microsoft.EntityFrameworkCore;
using EmployeeService.Data;

namespace EmployeeService.Repositories
{
    public class SqlRawRepository : ISqlRawRepository
    {
        private readonly ApplicationDbContext _context;

        public SqlRawRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> ExecuteStoredProcedureGetAsync<T>(string sql, params object[] parameters) where T : class
        {
            return await _context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<int> ExecuteStoredProcedureNonQueryAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
    }
}
