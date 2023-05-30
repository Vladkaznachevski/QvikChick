using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;
using Data;
using KvikChik.Models.ViewModels;
using KvikChik.Models.ViewModels.Default;
using Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KvikChik.Controllers
{
    public class AdminFoodController : Controller
    {
            private readonly ApplicationContext _context;
            private IFoodService _FoodService;

            public AdminFoodController(IFoodService FoodService, ApplicationContext context)
            {
                _FoodService = FoodService;
                _context = context;
        }

            public async Task<IActionResult> FoodsList(string search, int? food, SortState sortOrder = SortState.NameDesc, int page = 1)
            {
                int pageSize = 2;

                IQueryable<Food> foods = _context.Foods;

 
                if (!String.IsNullOrEmpty(search))
                {
                    foods = foods.Where(p => p.Name.Contains(search));  
                }



            switch (sortOrder)
            {
                case SortState.NameDesc:
                    foods = foods.OrderByDescending(s => s.Name);
                    break;
            }


            var count = foods.Count();
            var items = foods.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            FoodsListViewModel model = new FoodsListViewModel
                (
                    items,
                    new PageViewModel(count, page, pageSize),
                    new SortViewModel(sortOrder),
                    new FilterViewModel(_context.Foods.ToList(), food, search)
                );


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
