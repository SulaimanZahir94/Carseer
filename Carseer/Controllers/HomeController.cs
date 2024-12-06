using Carseer.Models;
using Carseer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Carseer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehicleService _vehicleService;

        public HomeController(ILogger<HomeController> logger, VehicleService vehicleService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            var makes = await _vehicleService.GetAllMakes();
            ViewBag.Makes = makes.Select(m => new SelectListItem(m.Make_Name, m.Make_ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int selectedMakeId, int year, string selectedVehicleType)
        {
            var vehicleTypes = await _vehicleService.GetVehicleTypesForMake(selectedMakeId);
            ViewBag.VehicleTypes = vehicleTypes.Select(v => new SelectListItem(v.VehicleTypeName, v.VehicleTypeName)).ToList();

            var models = await _vehicleService.GetModelsForMakeAndYear(selectedMakeId, year, selectedVehicleType);
            return View(models);
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