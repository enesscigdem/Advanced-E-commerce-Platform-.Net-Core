using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var orders = await orderService.Orders();
            return View(orders);
        }
        [HttpPost]
        public async Task<IActionResult> Complete([FromForm] int id)
        {
            await orderService.Complete(id);
            return RedirectToAction("Index");
        }
    }
}