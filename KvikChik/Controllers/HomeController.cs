using Data;
using Microsoft.AspNetCore.Mvc;
using Service.FoodSer;

using KvikChik.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KvikChik.Controllers
{
    public class HomeController : Controller
    {

        private IFoodService _FoodService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IFoodService foodService)
        {
            _logger = logger;
            _FoodService = foodService;
        }

        public IActionResult Index()
        {
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
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}