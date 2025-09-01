using System.Linq.Expressions;
using EmployeeService.Entities;

namespace EmployeeService.Extensions
{
    public class FiltersExtensions<T> where T : BaseEntity
    {
        public static Expression<Func<T, bool>> CombineFilters(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(
                Expression.Invoke(first, parameter),
                Expression.Invoke(second, parameter)
            );
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        public static Expression<Func<T, bool>> AddGlobalFilter(Expression<Func<T, bool>> filter, bool includeDeleted = false)
        {
            if (includeDeleted == false)
                return CombineFilters(filter, x => x.IsDeleted == false);
            else
                return filter;
        }
    }
}
