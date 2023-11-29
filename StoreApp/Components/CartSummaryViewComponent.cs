using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cart)
        {
            _cart = cart;
        }
        // Burada string döndürdüğümüz için herhangibir view sayfasına ihtiyaç duymadık.
        public string Invoke()
        {
            return _cart.Lines.Count().ToString();
        }
    }
}