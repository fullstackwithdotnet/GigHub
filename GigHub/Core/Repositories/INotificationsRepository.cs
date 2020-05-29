using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetNewNotifications(string userId);

        List<UserNotification> GetUserNotifications(string userId);
    }
}