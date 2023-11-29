using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ShowcaseViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await productService.GetShowcaseProducts();
            return View(products);
        }
    }
}