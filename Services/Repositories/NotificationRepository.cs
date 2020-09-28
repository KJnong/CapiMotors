using CapiMotors.Data;
using CapiMotors.Data.Interfaces;
using CapiMotors.Models;
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

        public List<Notification> Notifications(int Id)
        {
            var notification = context.Notifications.Where(n => n.VehicleId == Id).ToList();

            return notification;
        }

        public void AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);
        }
    }
}
