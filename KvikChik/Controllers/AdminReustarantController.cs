using Microsoft.AspNetCore.Mvc;
using Service.ReustarantSer;
using Data;
using KvikChik.Models.ViewModels;
namespace KvikChik.Controllers
{
    public class AdminReustarantController : Controller
    {

        private IReustarantService _ReustarantService;

        public AdminReustarantController(IReustarantService ReustarantService)
        {
            _ReustarantService = ReustarantService;
        }

        public IActionResult ReustarantsList()
        {
            List<ReustarantViewModel> model = new List<ReustarantViewModel>();
            List<Reustarant> Reustarants = _ReustarantService.GetReustarants();


            foreach (Reustarant Reustarant in Reustarants)
            {
                ReustarantViewModel bvm = new ReustarantViewModel
                {
                    Id = Reustarant.Id,
                    Address = Reustarant.Address,
                    CreatedDate = Reustarant.CreatedDate,
                    ModifiedDate = Reustarant.ModifiedDate
                };

                model.Add(bvm);
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ReustarantViewModel model = new ReustarantViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(ReustarantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reustarant Reustarant = new Reustarant()
                {
                    Id = model.Id,
                    Address = model.Address,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _ReustarantService.CreateReustarant(Reustarant);

                return RedirectToAction("ReustarantsList", "AdminReustarant");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Reustarant Reustarant = _ReustarantService.GetReustarantById(Id);
            ReustarantViewModel model = new ReustarantViewModel
            {
                Id = Id,
                Address = Reustarant.Address,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ReustarantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reustarant Reustarant = _ReustarantService.GetReustarantById(model.Id);

                Reustarant.Address = model.Address;
                Reustarant.ModifiedDate = DateTime.Now;

                _ReustarantService.UpdateReustarant(Reustarant);

                return RedirectToAction("ReustarantsList", "AdminReustarant");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _ReustarantService.DeleteReustarant(Id);
            return RedirectToAction("ReustarantsList", "AdminReustarant");
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }


    }
}
