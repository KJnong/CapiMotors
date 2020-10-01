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

namespace CapiMotors.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductRepository productRepository;
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
            this.productRepository = vehicleRepository;
            this.unitOfWork = unitOfWork;
            this.imagesRepositories = imagesRepositories;
            this.notificationRepository = notificationRepository;
        }


        public ActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var notifications = notificationRepository.GetSellerNotifications(userId);
            var vehicles = productRepository.GetProductBySeller(userId);

            ProductViewModel model = new ProductViewModel
            {
                Notifications = notifications,
                Products = vehicles
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var imagesFromDatabase = imagesRepositories.Images(id);
            var product = productRepository.GetProduct(id);

            List<string> images = new List<string>();

            foreach (var image in imagesFromDatabase)
            {
                images.Add(image.Path);
            }

            ProductDetailViewModel detail = new ProductDetailViewModel
            {
                Images = images,
                Product = product
            };

            return View(detail);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFormViewModel form)
        {
            if (!ModelState.IsValid || !form.Images.Any())
            {
                return RedirectToAction("Index", "Home"); //TODO: Redirect to error something
            }

            var userId = userManager.GetUserId(HttpContext.User);
            List<Image> imagesObject = new List<Image>();

            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\images");

            //for other images(multiple images)
            for (int i = 0; i < form.Images.Count; i++)
            {
                //for unique fileName
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + form.Images[i].FileName;
                var ImagesfilePath = Path.Combine(uploadsFolder, uniqueFileName);
                form.Images[i].CopyTo(new FileStream(ImagesfilePath, FileMode.Create));

                Image images = new Image
                {
                    Path = uniqueFileName,
                    Default = i == 0
                };

                imagesObject.Add(images);
            }

            Product product = new Product
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
                Images = imagesObject
            };

            productRepository.AddProduct(product);
            unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
