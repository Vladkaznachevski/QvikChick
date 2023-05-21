using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;
using Data;
using KvikChik.Models.ViewModels;
using Repository.ShopCartRepo;

namespace KvikChik.Controllers
{
    public class ShopCartController : Controller
    {
        private IFoodService _FoodService;

        private ShopCartRepository _shopCartRepository;

        public ShopCartController(ShopCartRepository shopCartRepository, IFoodService FoodService)
        {
            _shopCartRepository = shopCartRepository;
            _FoodService = FoodService;
        } 

        public ViewResult Index()
        {
            var items = _shopCartRepository.GetShopItems();
            _shopCartRepository.listShopItems = items;

            var obj = new ShopCartViewModel { ShopCartRepository = _shopCartRepository };

        return View(obj);
        
        }

        public RedirectToActionResult AddToCart(int id) {
        
            Food item = _FoodService.GetFoodById(id);
            _shopCartRepository.AddToCart(item);


            return RedirectToAction("Index");
        }


    }
}
