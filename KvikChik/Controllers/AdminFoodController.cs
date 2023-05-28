using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;
using Data;
using KvikChik.Models.ViewModels;
using KvikChik.Models.ViewModels.Default;

namespace KvikChik.Controllers
{
    public class AdminFoodController : Controller
    {

            private IFoodService _FoodService;

            public AdminFoodController(IFoodService FoodService)
            {
                _FoodService = FoodService;
            }

            public async Task<IActionResult> FoodsList(string? search, SortState sortOrder = SortState.NameAsc, int page = 1)
            {
                int pageSize = 2;
                List<Food> model = new List<Food>();
                List<Food> Foods = _FoodService.GetFoods();


                foreach (Food Food in Foods)
                {
                    Food bvm = new Food
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

                model = sortOrder switch
                {
                    SortState.NameDesc => model.OrderByDescending(b => b.Name).ToList(),
                    _ => model.OrderBy(b => b.Name).ToList()
                };


                int count = model.Count();
                model = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                FoodsListViewModel model2 = new FoodsListViewModel
                (
                    Foods,
                    new PageViewModel(count, page, pageSize),
                    new SortViewModel(sortOrder)
                );







            return View(model2);
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

            public IActionResult Delete(int Id)
            {
                _FoodService.DeleteFood(Id);
                return RedirectToAction("FoodsList", "AdminFood");
            }


            [HttpGet]
            public IActionResult Index()
            {
               
                return View();
            }


    }
}
