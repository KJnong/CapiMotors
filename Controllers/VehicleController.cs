using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using CapiMotors.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers
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


        [Authorize]
        public ActionResult Create()
        {
            VehicleFormViewModel model = new VehicleFormViewModel { Action = "Create" };

            return View("VehicleForm", model);
        }


        public ActionResult Details(int id)
        {
            var imagesFromDatabase = imagesRepositories.Images(id);
            var vehicle = vehicleRepository.GetVehicle(id);
            
            List<string> images = new List<string>();

            foreach(var image in imagesFromDatabase)
            {
                images.Add(image.ImageName);
            }

            VehicleInfoViewModel vehicleInfoViewModel = new VehicleInfoViewModel
            {
                ImagesNames = images,
                Vehicle = vehicle
            };
            
            return View("VehicleInfo", vehicleInfoViewModel);
        }


        [Authorize]
        public ActionResult AdminVehicles()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var notifications = notificationRepository.GetSellerNotifications(userId);
            var vehicles = vehicleRepository.GetSellerVehicles(userId);

            VehicleViewModel model = new VehicleViewModel
            {
                Notifications = notifications,
                Vehicles = vehicles
            };

            return View("AdminVehicles", model);
        }

     
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleFormViewModel form)
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(HttpContext.User);
                List<Images> imagesObject = new List<Images>();
                string uniqueMainImageName = null;

                if (form.OtherImages != null && form.MainImage !=null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\images");

                    //for unique fileName
                    uniqueMainImageName = Guid.NewGuid().ToString() + "_" + (form.MainImage.FileName);

                    var filePath = Path.Combine(uploadsFolder, uniqueMainImageName);

                    //copying uploaded image to image folder
                    form.MainImage.CopyTo(new FileStream(filePath, FileMode.Create));

                    //for other images(multiple images)
                    foreach (var image in form.OtherImages)
                    { 
                        //for unique fileName
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                        var OtherImagefilePath = Path.Combine(uploadsFolder, uniqueFileName);
                        image.CopyTo(new FileStream(OtherImagefilePath, FileMode.Create));

                        Images images = new Images
                        {
                            ImageName = uniqueFileName
                        };

                        imagesObject.Add(images);
                    }

                }

                Vehicle vehicle = new Vehicle
                {
                    Make = form.Make,
                    Model = form.Model,
                    Year = form.Year,
                    Colour = form.Colour,
                    PreviouslyOwned = form.PreviouslyOwned,
                    TowBar = form.TowBar,
                    SunRoof = form.SunRoof,
                    SellerId = userId,
                    Price = form.Price,
                    OtherImages = imagesObject,
                    MainImageName = uniqueMainImageName,
                    Status = form.Status
                };
              
                vehicleRepository.AddVehicle(vehicle);
                unitOfWork.Complete();
            }

            return RedirectToAction("Index", "Home");
        }

    
        [Authorize]
        public ActionResult Edit(int id)
        {
            var vehicle = vehicleRepository.GetVehicle(id);

            VehicleFormViewModel model = new VehicleFormViewModel
            {
                Action = "Update",
                Id = id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Price = vehicle.Price,
                Colour = vehicle.Colour,
                Year = vehicle.Year,
                PreviouslyOwned = vehicle.PreviouslyOwned,
                SunRoof = vehicle.SunRoof,
                TowBar = vehicle.TowBar,
                Status = vehicle.Status,
            };


            return View("VehicleForm", model);
        }

        [Authorize]
        public IActionResult Update(VehicleFormViewModel form)
        {
            var vehicle = vehicleRepository.GetVehicle(form.Id);
            vehicle.Update(form);
            unitOfWork.Complete();

            return RedirectToAction("AdminVehicles", "Vehicle");
        }
    }
}
