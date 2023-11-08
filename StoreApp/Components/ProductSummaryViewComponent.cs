using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductSummaryViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<string> InvokeAsync()
        {
            var count = await productService.GetProductCount();
            return count.ToString();
        }
    }
}