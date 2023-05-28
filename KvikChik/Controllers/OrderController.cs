using Microsoft.AspNetCore.Mvc;
using Repository.ShopCartRepo;
using Repository;
using Repository.OrderRepo;
using Service.OrderSer;
using Data;

namespace KvikChik.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService allOrders;

        private readonly ShopCartRepository shopCart;
        public OrderController(IOrderService allOrders, ShopCartRepository shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopItems();

            if(shopCart.listShopItems.Count == 0) 
            {
                ModelState.AddModelError("", "нужны товары");
            }

            if(ModelState.IsValid) { 
            allOrders.CreateOrder(order);

            return RedirectToAction("Complete");
            }
            return View();
        }


        public ActionResult Complete() {

            ViewBag.Message = "заказ собран";
        return View();
       }

    }
}
