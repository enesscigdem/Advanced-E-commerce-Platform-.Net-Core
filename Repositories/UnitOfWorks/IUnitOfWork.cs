using Repositories.Abstract;
using Repositories.UnitOfWorks;

namespace Repositories.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        Task<int> SaveAsync();
        int Save();
    }
}