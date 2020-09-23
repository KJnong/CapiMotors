using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CapiMotors.Models;
using CapiMotors.Data.Interfaces;

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

        public IActionResult Index()
        {
            var vehicles = vehicleRepository.GetAllVehicles();

            return View("ListedVehicles", vehicles);
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
