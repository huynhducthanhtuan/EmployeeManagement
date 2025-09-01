using EmployeeService.Interfaces;
using EmployeeService.Entities;
using Microsoft.EntityFrameworkCore;
using EmployeeService.Data;
using System.Linq.Expressions;

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

        public async Task<T> GetItemAsync(string key)
        {
            return await _dbSet.FindAsync(key);
        }

        public async Task<T> GetItemMetadataAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> AddItemAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateItemAsync(string key, T entity)
        {
            var existingEntity = await _dbSet.FindAsync(key);
            if (existingEntity == null) throw new KeyNotFoundException($"Entity with key {key} not found.");
            entity.UpdatedDate = DateTime.Now;
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteItemAsync(string key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity == null) throw new KeyNotFoundException($"Entity with key {key} not found.");
            entity.IsDeleted = true;
            _dbSet.Attach(entity);
            _context.Entry(entity).Property(e => e.IsDeleted).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task HardDeleteItemAsync(string key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity == null) throw new KeyNotFoundException($"Entity with key {key} not found.");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
