using CapiMotors.Models;
using System.Collections.Generic;

namespace CapiMotors.Data.Interfaces
{
    public interface INotificationRepository
    {
        void AddNotification(Notification notification);
        List<Notification> GetNotifications(int Id);
    }
}