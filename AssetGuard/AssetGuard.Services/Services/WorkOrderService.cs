using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<WorkOrder> CreateWorkOrderAsync(WorkOrder workOrder)
        {
            workOrder.TicketNumber = $"WO-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
            await _unitOfWork.Repository<WorkOrder>().AddAsync(workOrder);
            await _unitOfWork.CompleteAsync();
            return workOrder;
        }

        public async Task<WorkOrder> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<WorkOrder>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<WorkOrder>> GetByAssetIdAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<WorkOrder>().GetAllAsync();
            return all.Where(w => w.AssetId == assetId);
        }

        public async Task<IEnumerable<WorkOrder>> GetByTechnicianIdAsync(int technicianId)
        {
            var all = await _unitOfWork.Repository<WorkOrder>().GetAllAsync();
            return all.Where(w => w.AssignedTechnicianId == technicianId);
        }

        public async Task<IEnumerable<WorkOrder>> GetByStatusAsync(WorkOrderStatus status)
        {
            var all = await _unitOfWork.Repository<WorkOrder>().GetAllAsync();
            return all.Where(w => w.Status == status);
        }

        public async Task UpdateStatusAsync(int id, WorkOrderStatus status, int? userId)
        {
            var wo = await GetByIdAsync(id);
            if (wo != null)
            {
                wo.Status = status;
                if (status == WorkOrderStatus.Completed)
                {
                    wo.CompletedAt = DateTime.UtcNow;
                }
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task AssignTechnicianAsync(int id, int technicianId)
        {
            var wo = await GetByIdAsync(id);
            if (wo != null)
            {
                wo.AssignedTechnicianId = technicianId;
                wo.Status = WorkOrderStatus.Scheduled;
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<WorkOrderTask> AddTaskAsync(int workOrderId, string description, decimal estimatedHours)
        {
            var task = new WorkOrderTask
            {
                WorkOrderId = workOrderId,
                Description = description,
                EstimatedHours = estimatedHours
            };
            await _unitOfWork.Repository<WorkOrderTask>().AddAsync(task);
            await _unitOfWork.CompleteAsync();
            return task;
        }

        public async Task CompleteTaskAsync(int taskId, int completedById, decimal actualHours)
        {
            var task = await _unitOfWork.Repository<WorkOrderTask>().GetByIdAsync(taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                task.CompletedAt = DateTime.UtcNow;
                task.CompletedById = completedById;
                task.ActualHours = actualHours;
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
