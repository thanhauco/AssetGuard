using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SendAsync(SendNotificationDto dto)
        {
            var notification = new Notification
            {
                UserId = dto.UserId,
                Subject = dto.Subject,
                Body = dto.Body,
                Channel = dto.Channel,
                IsRead = false
            };

            await _unitOfWork.Repository<Notification>().AddAsync(notification);
            
            // In a real app, here we would call EmailService or SMSService based on Channel
            
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<dynamic>> GetUserNotificationsAsync(int userId)
        {
            var notifications = await _unitOfWork.Repository<Notification>()
                                    .FindAsync(n => n.UserId == userId && !n.IsRead);
            
            return notifications.OrderByDescending(n => n.CreatedAt).Select(n => new
            {
                n.Id,
                n.Subject,
                n.Body,
                n.CreatedAt
            });
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var n = await _unitOfWork.Repository<Notification>().GetByIdAsync(notificationId);
            if (n != null)
            {
                n.IsRead = true;
                n.ReadAt = DateTime.UtcNow;
                await _unitOfWork.Repository<Notification>().UpdateAsync(n);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
