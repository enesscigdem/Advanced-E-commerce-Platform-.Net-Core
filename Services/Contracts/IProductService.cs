using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsWithDetails(ProductRequestParameters px);
        Task<Product?> GetOneProduct(int ProductId);
        Task<ProductDtoForUpdate> GetOneProductForUpdate(int ProductId);
        Task CreateProduct(ProductDtoForInsertion product);
        Task UpdateProduct(ProductDtoForUpdate productDto);
        Task DeleteProduct(int id);
        Task<int> GetProductCount();
        Task<IQueryable<Product>> GetShowcaseProducts();
    }
}