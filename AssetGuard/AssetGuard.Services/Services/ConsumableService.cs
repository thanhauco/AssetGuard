using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class ConsumableService : IConsumableService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsumableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Consumable> CreateConsumableAsync(Consumable consumable)
        {
            await _unitOfWork.Repository<Consumable>().AddAsync(consumable);
            await _unitOfWork.CompleteAsync();
            return consumable;
        }

        public async Task<Consumable> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Consumable>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Consumable>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Consumable>().GetAllAsync();
        }

        public async Task<IEnumerable<Consumable>> GetLowStockAsync()
        {
            var all = await GetAllAsync();
            return all.Where(c => c.CurrentStock <= c.MinStockLevel && c.IsActive);
        }

        public async Task<StockMovement> AddStockAsync(int consumableId, int quantity, string reason, int performedById)
        {
            var consumable = await GetByIdAsync(consumableId);
            var previousStock = consumable.CurrentStock;
            consumable.CurrentStock += quantity;

            var movement = new StockMovement
            {
                ConsumableId = consumableId,
                MovementType = "In",
                Quantity = quantity,
                PreviousStock = previousStock,
                NewStock = consumable.CurrentStock,
                PerformedById = performedById,
                Reason = reason
            };

            await _unitOfWork.Repository<StockMovement>().AddAsync(movement);
            await _unitOfWork.CompleteAsync();
            return movement;
        }

        public async Task<StockMovement> RemoveStockAsync(int consumableId, int quantity, string reason, int performedById)
        {
            var consumable = await GetByIdAsync(consumableId);
            var previousStock = consumable.CurrentStock;
            consumable.CurrentStock -= quantity;

            var movement = new StockMovement
            {
                ConsumableId = consumableId,
                MovementType = "Out",
                Quantity = quantity,
                PreviousStock = previousStock,
                NewStock = consumable.CurrentStock,
                PerformedById = performedById,
                Reason = reason
            };

            await _unitOfWork.Repository<StockMovement>().AddAsync(movement);

            if (consumable.CurrentStock <= consumable.MinStockLevel)
            {
                var alert = new ReorderAlert
                {
                    ConsumableId = consumableId,
                    CurrentStock = consumable.CurrentStock,
                    MinStockLevel = consumable.MinStockLevel
                };
                await _unitOfWork.Repository<ReorderAlert>().AddAsync(alert);
            }

            await _unitOfWork.CompleteAsync();
            return movement;
        }

        public async Task<IEnumerable<StockMovement>> GetMovementHistoryAsync(int consumableId)
        {
            var all = await _unitOfWork.Repository<StockMovement>().GetAllAsync();
            return all.Where(m => m.ConsumableId == consumableId).OrderByDescending(m => m.MovementDate);
        }

        public async Task<IEnumerable<ReorderAlert>> GetActiveAlertsAsync()
        {
            var all = await _unitOfWork.Repository<ReorderAlert>().GetAllAsync();
            return all.Where(a => !a.IsAcknowledged);
        }

        public async Task AcknowledgeAlertAsync(int alertId, int? purchaseRequestId)
        {
            var alert = await _unitOfWork.Repository<ReorderAlert>().GetByIdAsync(alertId);
            alert.IsAcknowledged = true;
            alert.AcknowledgedAt = DateTime.UtcNow;
            alert.PurchaseRequestId = purchaseRequestId;
            await _unitOfWork.CompleteAsync();
        }
    }
}
