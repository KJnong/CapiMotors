using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CapiMotors.Models;
using CapiMotors.Data.Interfaces;
using CapiMotors.Services.ViewModels;

namespace CapiMotors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository vehicleRepository;

        public HomeController(ILogger<HomeController> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            this.vehicleRepository = vehicleRepository;
        }

        public IActionResult Index( bool renderSearch = false, List<Vehicle> searchedV = null)
        {
            var Allvehicles = vehicleRepository.GetAllVehicles();

            VehicleViewModel model = new VehicleViewModel
            {
                Vehicles = renderSearch ? searchedV.Where(s => s.Status == StatusType.Published).ToList() : Allvehicles.OrderByDescending(o => o.Id).Take(4).ToList(),
                MakeSearchList = Allvehicles.Select(m => m.Make).Distinct().ToList()
            }; 

            return View("PublishedVehicles", model);
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
