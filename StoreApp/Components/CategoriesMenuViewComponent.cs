using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoriesMenuViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetAllCategories();
            return View(categories);
        }
    }
}