using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IConsumableService
    {
        Task<Consumable> CreateConsumableAsync(Consumable consumable);
        Task<Consumable> GetByIdAsync(int id);
        Task<IEnumerable<Consumable>> GetAllAsync();
        Task<IEnumerable<Consumable>> GetLowStockAsync();
        
        Task<StockMovement> AddStockAsync(int consumableId, int quantity, string reason, int performedById);
        Task<StockMovement> RemoveStockAsync(int consumableId, int quantity, string reason, int performedById);
        Task<IEnumerable<StockMovement>> GetMovementHistoryAsync(int consumableId);
        
        Task<IEnumerable<ReorderAlert>> GetActiveAlertsAsync();
        Task AcknowledgeAlertAsync(int alertId, int? purchaseRequestId);
    }
}
