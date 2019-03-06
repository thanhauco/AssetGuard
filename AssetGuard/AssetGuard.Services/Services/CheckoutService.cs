using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CheckoutSession> CheckoutAssetAsync(int assetId, int employeeId, string deviceId, string condition)
        {
            var session = new CheckoutSession
            {
                AssetId = assetId,
                EmployeeId = employeeId,
                DeviceId = deviceId,
                ConditionAtCheckout = condition,
                Status = CheckoutStatus.Active,
                ExpectedReturnTime = DateTime.UtcNow.AddDays(7)
            };

            await _unitOfWork.Repository<CheckoutSession>().AddAsync(session);

            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(assetId);
            asset.Status = AssetStatus.Assigned;

            await _unitOfWork.CompleteAsync();
            return session;
        }

        public async Task<CheckoutSession> ReturnAssetAsync(int sessionId, string condition, string notes)
        {
            var session = await GetSessionByIdAsync(sessionId);
            session.Status = CheckoutStatus.Returned;
            session.ActualReturnTime = DateTime.UtcNow;
            session.ConditionAtReturn = condition;
            session.Notes = notes;

            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(session.AssetId);
            asset.Status = AssetStatus.Available;

            await _unitOfWork.CompleteAsync();
            return session;
        }

        public async Task<CheckoutSession> GetSessionByIdAsync(int id)
        {
            return await _unitOfWork.Repository<CheckoutSession>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<CheckoutSession>> GetActiveCheckoutsAsync()
        {
            var all = await _unitOfWork.Repository<CheckoutSession>().GetAllAsync();
            return all.Where(s => s.Status == CheckoutStatus.Active);
        }

        public async Task<IEnumerable<CheckoutSession>> GetOverdueCheckoutsAsync()
        {
            var active = await GetActiveCheckoutsAsync();
            return active.Where(s => s.ExpectedReturnTime < DateTime.UtcNow);
        }

        public async Task<IEnumerable<CheckoutSession>> GetCheckoutsForEmployeeAsync(int employeeId)
        {
            var all = await _unitOfWork.Repository<CheckoutSession>().GetAllAsync();
            return all.Where(s => s.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<CheckoutSession>> GetCheckoutHistoryForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<CheckoutSession>().GetAllAsync();
            return all.Where(s => s.AssetId == assetId).OrderByDescending(s => s.CheckoutTime);
        }

        public async Task ProcessOfflineQueueAsync(string deviceId)
        {
            var queue = await _unitOfWork.Repository<OfflineSyncQueue>().GetAllAsync();
            var pending = queue.Where(q => q.DeviceId == deviceId && !q.IsProcessed);

            foreach (var item in pending)
            {
                item.IsProcessed = true;
                item.ProcessedAt = DateTime.UtcNow;
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task<MobileDevice> RegisterDeviceAsync(string deviceId, string name, string platform, int? assignedToId)
        {
            var device = new MobileDevice
            {
                DeviceId = deviceId,
                DeviceName = name,
                Platform = platform,
                AssignedToId = assignedToId
            };

            await _unitOfWork.Repository<MobileDevice>().AddAsync(device);
            await _unitOfWork.CompleteAsync();
            return device;
        }
    }
}
