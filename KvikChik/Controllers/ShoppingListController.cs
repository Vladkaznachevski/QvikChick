using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;
using Data;
using KvikChik.Models.ViewModels;

namespace KvikChik.Controllers
{
    public class ShoppingListController : Controller
    {
        private IFoodService _FoodService;

        public ShoppingListController(IFoodService FoodService)
        {
            _FoodService = FoodService;
        }

        public IActionResult ShoppingList()
        {
            List<ShoppingListViewModel> model = new List<ShoppingListViewModel>();
            List<FoodViewModel> modelList = new List<FoodViewModel>();
            List<Food> Foods = _FoodService.GetFoods();


            foreach (Food Food in Foods)
            {
                FoodViewModel bvm = new FoodViewModel
                {
                    Id = Food.Id,
                    Name = Food.Name,
                    Size = Food.Size,
                    Description = Food.Description,
                    CreatedDate = Food.CreatedDate,
                    ModifiedDate = Food.ModifiedDate
                };
               
                modelList.Add(bvm);
            }
            ViewBag.FoodList = modelList;
            return View(model);
        }



        [HttpGet]
        public IActionResult Create()
        {
            FoodViewModel model = new FoodViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(FoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Food Food = new Food()
                {
                    Id = model.Id,
                    Size = model.Size,
                    Name = model.Name,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _FoodService.CreateFood(Food);

                return RedirectToAction("FoodsList", "AdminFood");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Food Food = _FoodService.GetFoodById(Id);
            FoodViewModel model = new FoodViewModel
            {
                Id = Id,
                Name = Food.Name,
                Description = Food.Description,
                Size = Food.Size,

            };
            return View(model);
        }




        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

    }
}
