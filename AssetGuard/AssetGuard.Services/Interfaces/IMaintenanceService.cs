using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IMaintenanceService
    {
        Task<IEnumerable<MaintenanceRecordDto>> GetMaintenanceHistoryAsync(int assetId);
        Task<MaintenanceRecordDto> AddMaintenanceRecordAsync(CreateMaintenanceRecordDto maintenanceDto);
    }
}
