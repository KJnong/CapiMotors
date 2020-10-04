using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using CapiMotors.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CapiMotors.Controllers.Admin
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


        public IActionResult Notification(int id)
        {
            var notification = notificationRepository.GetNotifications(id);

            return View(notification);
        }
    }
}
