using Microsoft.AspNetCore.Mvc;
using Repository.ShopCartRepo;
using Repository;
using Repository.OrderRepo;

namespace KvikChik.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrdersRepository allOrders;

        private readonly ShopCartRepository shopCart;
        public OrderController(IOrdersRepository allOrders, ShopCartRepository shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}
