using Entities.Models;
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

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProducts();
            return View(model);
        }

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var model = await productService.GetOneProduct(id);
            return View(model);
        }
    }
}