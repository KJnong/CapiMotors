using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using CapiMotors.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository notificationRepository;
        private readonly IUnitOfWork unitOfWork;

        public NotificationController(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            this.notificationRepository = notificationRepository;
            this.unitOfWork = unitOfWork;
        }
        public IActionResult AddNotification(ProductDetailViewModel model)
        {
            Notification notification = new Notification
            {
                Name = model.Name,
                Email = model.Email,
                Numbers = model.Phone,
                ProductId = model.VehicleId,
                SellerId = model.SellerId
            };

            notificationRepository.AddNotification(notification);
            unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Notification(int id)
        {
            var notification = notificationRepository.GetNotifications(id);

            return View(notification);
        }
    }
}
