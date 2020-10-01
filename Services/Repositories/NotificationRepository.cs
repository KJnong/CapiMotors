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
            return context.Notifications.Where(v => v.ProductId == id).ToList();
        }

        public List<Notification> GetSellerNotifications(string userId)
        {
            return context.Notifications.Where(v => v.SellerId == userId).ToList();
        }


        public void AddNotification(Notification notification)
        {
            context.Notifications.Add(notification);
        }
    }
}
