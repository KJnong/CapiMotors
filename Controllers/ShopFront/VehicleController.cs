using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using CapiMotors.Services.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers.ShopFront
{
    public class VehicleController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IImagesRepositories imagesRepositories;
        private readonly INotificationRepository notificationRepository;

        public VehicleController(IWebHostEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            IImagesRepositories imagesRepositories,
            INotificationRepository notificationRepository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.vehicleRepository = vehicleRepository;
            this.unitOfWork = unitOfWork;
            this.imagesRepositories = imagesRepositories;
            this.notificationRepository = notificationRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var imagesFromDatabase = imagesRepositories.Images(id);
            var vehicle = vehicleRepository.GetVehicle(id);

            List<string> images = new List<string>();

            foreach (var image in imagesFromDatabase)
            {
                images.Add(image.ImageName);
            }

            VehicleInfoViewModel vehicleInfoViewModel = new VehicleInfoViewModel
            {
                ImagesNames = images,
                Vehicle = vehicle
            };

            return View("VehicleDetails", vehicleInfoViewModel);
        }

    }
}
