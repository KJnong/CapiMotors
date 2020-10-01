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
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductRepository vehicleRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IImagesRepositories imagesRepositories;
        private readonly INotificationRepository notificationRepository;

        public ProductController(IWebHostEnvironment hostingEnvironment,
            UserManager<ApplicationUser> userManager,
            IProductRepository vehicleRepository,
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


        // GET: VehileController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var imagesFromDatabase = imagesRepositories.Images(id);
            var vehicle = vehicleRepository.GetProduct(id);
            
            List<string> images = new List<string>();

            foreach(var image in imagesFromDatabase)
            {
                images.Add(image.Path);
            }

            ProductDetailViewModel detailsVM = new ProductDetailViewModel
            {
                Images = images,
                Product = vehicle
            };
            
            return View(detailsVM);
        }
    }
}
