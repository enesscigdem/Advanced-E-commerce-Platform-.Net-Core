using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;
using StoreApp.Models;

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
            var products = await productService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = await productService.GetTotalProductCount(p)
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var model = await productService.GetOneProduct(id);
            return View(model);
        }
    }
}