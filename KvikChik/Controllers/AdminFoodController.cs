using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;
using Data;
using KvikChik.Models.ViewModels;
namespace KvikChik.Controllers
{
    public class AdminFoodController : Controller
    {

            private IFoodService _FoodService;

            public AdminFoodController(IFoodService FoodService)
            {
                _FoodService = FoodService;
            }

            public IActionResult FoodsList()
            {
                List<FoodViewModel> model = new List<FoodViewModel>();
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

                    model.Add(bvm);
                }
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
                        Id=model.Id,
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

            [HttpPost]
            public IActionResult Update(FoodViewModel model)
            {
                if (ModelState.IsValid)
                {
                    Food Food = _FoodService.GetFoodById(model.Id);

                    Food.Name = model.Name;
                    Food.Description = model.Description;
                    Food.Size = model.Size;
                    Food.ModifiedDate = DateTime.Now;

                    _FoodService.UpdateFood(Food);

                    return RedirectToAction("FoodsList", "AdminFood");
                }

                return View(model);
            }

            [HttpPost]
            public IActionResult Delete(int Id)
            {
                _FoodService.DeleteFood(Id);
                return RedirectToAction("FoodsList", "AdminFood");
            }





    }
}
