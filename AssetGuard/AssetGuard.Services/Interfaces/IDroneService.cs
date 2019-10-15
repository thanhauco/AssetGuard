using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IDroneService
    {
        Task<DroneFlight> ScheduleFlightAsync(DroneFlight flight);
        Task UpdateFlightStatusAsync(int flightId, string status);
        Task<InspectionImage> UploadImageAsync(int flightId, string url, double lat, double lng);
        Task<IEnumerable<Defect>> AnalyzeImageAsync(int imageId);
        Task<IEnumerable<Defect>> GetRecentDefectsAsync(int regionId);
        Task VerifyDefectAsync(int defectId, bool isReal);
    }
}
