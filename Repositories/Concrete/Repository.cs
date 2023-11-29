using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;

namespace Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly RepositoryContext dbContext;

        public Repository(RepositoryContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return query;
        }
        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate is not null)
                return await Table.CountAsync(predicate);
            return await Table.CountAsync();
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbContext.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}