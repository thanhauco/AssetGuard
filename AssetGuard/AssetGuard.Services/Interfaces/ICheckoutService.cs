using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task<CheckoutSession> CheckoutAssetAsync(int assetId, int employeeId, string deviceId, string condition);
        Task<CheckoutSession> ReturnAssetAsync(int sessionId, string condition, string notes);
        Task<CheckoutSession> GetSessionByIdAsync(int id);
        Task<IEnumerable<CheckoutSession>> GetActiveCheckoutsAsync();
        Task<IEnumerable<CheckoutSession>> GetOverdueCheckoutsAsync();
        Task<IEnumerable<CheckoutSession>> GetCheckoutsForEmployeeAsync(int employeeId);
        Task<IEnumerable<CheckoutSession>> GetCheckoutHistoryForAssetAsync(int assetId);
        Task ProcessOfflineQueueAsync(string deviceId);
        Task<MobileDevice> RegisterDeviceAsync(string deviceId, string name, string platform, int? assignedToId);
    }
}
