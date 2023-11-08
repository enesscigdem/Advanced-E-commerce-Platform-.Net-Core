using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetOneProduct(int ProductId);
        Task<ProductDtoForUpdate> GetOneProductForUpdate(int ProductId);
        Task CreateProduct(ProductDtoForInsertion product);
        Task UpdateProduct(ProductDtoForUpdate productDto);
        Task DeleteProduct(int id);
        Task<int> GetProductCount();
    }
}