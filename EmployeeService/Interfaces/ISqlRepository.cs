using System.Linq.Expressions;
using EmployeeService.Entities;

namespace EmployeeService.Interfaces
{
    public interface ISqlRepository<T> where T : BaseEntity
    {
        Task<T> GetItemAsync(string key);
        Task<T> GetItemMetadataAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> filter, bool includeDeleted = false);
        Task<T> AddItemAsync(T entity);
        Task UpdateItemAsync(string key, T entity);
        Task SoftDeleteItemAsync(string key);
        Task HardDeleteItemAsync(string key);
    }
}
