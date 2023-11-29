using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructre.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductService productService;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public CartModel(IProductService productService, Cart cartService)
        {
            this.productService = productService;
            Cart = cartService;
        }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public async Task<IActionResult> OnPost(int productId, string returnUrl)
        {
            Product? product = await productService.GetOneProduct(productId);
            if (product is not null)
            {
                // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                // HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
            // HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}