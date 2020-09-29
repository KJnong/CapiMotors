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

        public NotificationController(INotificationRepository notificationRepository)
        {
            this.notificationRepository = notificationRepository;
        }
        public IActionResult AddNotification(VehicleInfoViewModel model)
        {
            Notification notification = new Notification
            {
                Name = model.Name,
                Email = model.Email,
                Numbers = model.Phone,
                VehicleId = model.VehicleId
            };

            notificationRepository.AddNotification(notification);

            return RedirectToAction("Index", "Home");
        }
    }
}
