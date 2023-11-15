using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetAllProducts();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await GetCategoriesSelectList();
            return View();
        }
        private async Task<SelectList> GetCategoriesSelectList()
        {
            return new SelectList(await categoryService.GetAllCategories(), "CategoryId", "CategoryName", 1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName); //Concat=Birleştirme
                await productService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = await GetCategoriesSelectList();
            var model = await productService.GetOneProductForUpdate(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName); //Concat=Birleştirme

                await productService.UpdateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            if (ModelState.IsValid)
            {
                await productService.DeleteProduct(id);
            }
            return RedirectToAction("Index");
        }
    }
}