using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapiMotors.Services.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext context;
        public NotificationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Notification> GetNotifications(int id)
        {

            var notifications = context.Notifications.Where(v => v.VehicleId == id).ToList();



            return notifications;
        }


        public void AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);
        }
    }
}
