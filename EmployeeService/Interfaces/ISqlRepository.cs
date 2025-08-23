namespace EmployeeService.Interfaces
{
    public interface ISqlRepository<T> where T : class
    {
        Task<List<T>> GetAllItemsAsync();
        Task<T> GetItemByIdAsync(string id);
        Task<T> AddItemAsync(T entity);
        Task UpdateItemAsync(T entity);
        Task SoftDeleteItemAsync(string id);
        Task HardDeleteItemAsync(string id);
    }
}
