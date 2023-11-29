using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly Cart _cart;
        public OrderController(IOrderService orderService, Cart cart)
        {
            this.orderService = orderService;
            _cart = cart;
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
                ModelState.AddModelError("", "Sorry, your cart is empty.");

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                await orderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            else
                return View();
        }
    }
}