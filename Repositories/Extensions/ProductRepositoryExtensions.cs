using Entities.Models;
using Repositories.Abstract;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static async Task<IQueryable<Product>> FilterProducts(this IRepository<Product> repository, int? categoryId, string searchTerm, int MinPrice, int MaxPrice)
        {
            IQueryable<Product> query = await repository.GetAllAsync();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                query = query.Where(x => x.ProductName.ToLower().Contains(searchTerm));
            }

            return query.Where(prd => prd.Price >= MinPrice && prd.Price <= MaxPrice);
        }
        public static async Task<IEnumerable<Product>> ToPaginate(this IEnumerable<Product> products, int pageNumber, int pageSize)
        {
            return products
            .Skip(((pageNumber - 1) * pageSize))
            .Take(pageSize);
        }
    }
}