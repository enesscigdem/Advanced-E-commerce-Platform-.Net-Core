using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService productService;
        public Cart Cart { get; set; }
        public CartModel(IProductService productService, Cart cart)
        {
            this.productService = productService;
            Cart = cart;
        }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public async Task<IActionResult> OnPost(int productId, string returnUrl)
        {
            Product? product = await productService.GetOneProduct(productId);
            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page();
        }
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            return Page();
        }
    }
}