using EmployeeService.Data;
using EmployeeService.Entities;
using EmployeeService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Repositories
{
    public class SqlRepository<T> : ISqlRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllItemsAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<T> GetItemByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddItemAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateItemAsync(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);
            if (existingEntity == null) throw new KeyNotFoundException($"Entity with Id {entity.Id} not found.");
            entity.UpdatedDate = DateTime.Now;
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteItemAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException($"Entity with Id {id} not found.");
            entity.IsDeleted = true;
            _dbSet.Attach(entity);
            _context.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task HardDeleteItemAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException($"Entity with Id {id} not found.");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
