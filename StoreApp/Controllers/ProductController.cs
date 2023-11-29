using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index(ProductRequestParameters p)
        {
            var model = await productService.GetAllProductsWithDetails(p);
            return View(model);
        }

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var model = await productService.GetOneProduct(id);
            return View(model);
        }
    }
}