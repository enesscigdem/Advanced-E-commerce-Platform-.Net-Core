using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Repositories.UnitOfWorks;
using Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Repositories;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly RepositoryContext context;
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper, RepositoryContext context)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.context = context;
        }

        public async Task Complete(int id)
        {
            var order = await unitOfWork.GetRepository<Order>().GetAsync(x => x.OrderId.Equals(id));
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;
            await unitOfWork.SaveAsync();
        }

        public async Task<Order?> GetOneOrder(int id)
        {
            return await unitOfWork.GetRepository<Order>().GetAsync(x => x.OrderId == id);
        }

        public async Task<int> NumberOfInProcess()
        {
            return await unitOfWork.GetRepository<Order>().CountAsync(x => x.Shipped.Equals(false));
        }

        public async Task<IQueryable<Order>> Orders()
        {
            var ordersTask = await unitOfWork.GetRepository<Order>().GetAllAsync();

            return ordersTask.Include(x => x.Lines)
                         .ThenInclude(l => l.Product);
        }
        public async Task SaveOrder(Order order)
        {

            context.AttachRange(order.Lines.Select(l => l.Product));
            await unitOfWork.GetRepository<Order>().AddAsync(order);
            await unitOfWork.SaveAsync();
        }
    }
}