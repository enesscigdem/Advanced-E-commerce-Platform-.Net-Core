using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}