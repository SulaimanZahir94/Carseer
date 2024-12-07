using Carseer.Models;
using Carseer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Carseer.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMakes()
        {
            var response = await _httpClient.GetStringAsync("https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json");
            return Content(response, "application/json");
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            var response = await _httpClient.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json");
            return Content(response, "application/json");
        }

        [HttpGet]
        public async Task<IActionResult> GetModels(int makeId, int year)
        {
            var response = await _httpClient.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
            return Content(response, "application/json");
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