using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Repositories.UnitOfWorks;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateProduct(ProductDtoForInsertion productDto)
        {
            var map = mapper.Map<Product>(productDto);
            await unitOfWork.GetRepository<Product>().AddAsync(map);
            await unitOfWork.SaveAsync();
        }
        public async Task UpdateProduct(ProductDtoForUpdate productDtoForUpdate)
        {
            var map = mapper.Map<Product>(productDtoForUpdate);
            await unitOfWork.GetRepository<Product>().UpdateAsync(map);
            await unitOfWork.SaveAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => x.ProductId == id);
            await unitOfWork.GetRepository<Product>().DeleteAsync(product);
            await unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await unitOfWork.GetRepository<Product>().GetAllAsync();
        }

        public async Task<Product?> GetOneProduct(int ProductId)
        {
            return await unitOfWork.GetRepository<Product>().GetAsync(x => x.ProductId == ProductId);
        }
        public async Task<ProductDtoForUpdate> GetOneProductForUpdate(int ProductId)
        {
            var product = await unitOfWork.GetRepository<Product>().GetAsync(x => x.ProductId == ProductId);
            var productDto = mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }
        public async Task<int> GetProductCount()
        {
            return await unitOfWork.GetRepository<Product>().CountAsync();
        }
    }
}