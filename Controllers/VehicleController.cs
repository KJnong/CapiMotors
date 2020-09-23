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

        public VehicleController(IWebHostEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.vehicleRepository = vehicleRepository;
            this.unitOfWork = unitOfWork;
        }


        // GET: VehileController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehileController/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("VehicleForm");
        }

        // POST: VehileController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleFormViewModel form)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                var userId = userManager.GetUserId(HttpContext.User);

                if (form.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\images");

                    //for unique fileName
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + form.Image.FileName;

                    filePath = Path.Combine(uploadsFolder , uniqueFileName);

                    //copying uploaded image to image folder
                    form.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Vehicle vehicle = new Vehicle
                {
                    Make = form.Make,
                    Model = form.Model,
                    Date = form.Date,
                    Colour = form.Colour,
                    PreviouslyOwned = form.PreviouslyOwned,
                    TowBar = form.TowBar,
                    SunRoof = form.SunRoof,
                    ImagePath = filePath,
                    SellerId = userId
                };

                vehicleRepository.AddVehicle(vehicle);
                unitOfWork.Complete();
            }

            return View();
        }

        // GET: VehileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
