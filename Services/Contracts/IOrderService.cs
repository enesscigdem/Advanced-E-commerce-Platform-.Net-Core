using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        Task<IQueryable<Order>> Orders();
        Task<Order?> GetOneOrder(int id);
        Task Complete(int id);
        Task SaveOrder(Order order);
        Task<int> NumberOfInProcess();
    }
}