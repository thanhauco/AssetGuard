using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IGeolocationService
    {
        Task<AssetLocation> RecordLocationAsync(int assetId, double lat, double lng, string source, string deviceId);
        Task<AssetLocation> GetCurrentLocationAsync(int assetId);
        Task<IEnumerable<AssetLocation>> GetLocationHistoryAsync(int assetId, int limit);
        
        Task<GeoFence> CreateGeoFenceAsync(GeoFence fence);
        Task<IEnumerable<GeoFence>> GetActiveFencesAsync();
        Task<bool> IsAssetInFenceAsync(int assetId, int fenceId);
        
        Task<GeoFenceViolation> RecordViolationAsync(int fenceId, int assetId, string type, double lat, double lng);
        Task<IEnumerable<GeoFenceViolation>> GetUnacknowledgedViolationsAsync();
    }
}
