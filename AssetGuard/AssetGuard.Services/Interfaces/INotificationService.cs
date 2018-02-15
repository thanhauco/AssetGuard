using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(SendNotificationDto notification);
        Task<IEnumerable<dynamic>> GetUserNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);
    }
}
