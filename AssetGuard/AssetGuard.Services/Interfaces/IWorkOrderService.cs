using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IWorkOrderService
    {
        Task<WorkOrder> CreateWorkOrderAsync(WorkOrder workOrder);
        Task<WorkOrder> GetByIdAsync(int id);
        Task<IEnumerable<WorkOrder>> GetByAssetIdAsync(int assetId);
        Task<IEnumerable<WorkOrder>> GetByTechnicianIdAsync(int technicianId);
        Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status);
        
        Task UpdateStatusAsync(int id, WorkOrderStatus status, int? userId);
        Task AssignTechnicianAsync(int id, int technicianId);
        Task<WorkOrderTask> AddTaskAsync(int workOrderId, string description, decimal estimatedHours);
        Task CompleteTaskAsync(int taskId, int completedById, decimal actualHours);
    }
}
