using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class GeolocationService : IGeolocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GeolocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssetLocation> RecordLocationAsync(int assetId, double lat, double lng, string source, string deviceId)
        {
            var location = new AssetLocation
            {
                AssetId = assetId,
                Latitude = lat,
                Longitude = lng,
                Source = source,
                DeviceId = deviceId
            };

            await _unitOfWork.Repository<AssetLocation>().AddAsync(location);
            await _unitOfWork.CompleteAsync();
            return location;
        }

        public async Task<AssetLocation> GetCurrentLocationAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<AssetLocation>().GetAllAsync();
            return all.Where(l => l.AssetId == assetId).OrderByDescending(l => l.RecordedAt).FirstOrDefault();
        }

        public async Task<IEnumerable<AssetLocation>> GetLocationHistoryAsync(int assetId, int limit)
        {
            var all = await _unitOfWork.Repository<AssetLocation>().GetAllAsync();
            return all.Where(l => l.AssetId == assetId).OrderByDescending(l => l.RecordedAt).Take(limit);
        }

        public async Task<GeoFence> CreateGeoFenceAsync(GeoFence fence)
        {
            await _unitOfWork.Repository<GeoFence>().AddAsync(fence);
            await _unitOfWork.CompleteAsync();
            return fence;
        }

        public async Task<IEnumerable<GeoFence>> GetActiveFencesAsync()
        {
            var all = await _unitOfWork.Repository<GeoFence>().GetAllAsync();
            return all.Where(f => f.IsActive);
        }

        public async Task<bool> IsAssetInFenceAsync(int assetId, int fenceId)
        {
            var location = await GetCurrentLocationAsync(assetId);
            if (location == null) return false;

            var fence = await _unitOfWork.Repository<GeoFence>().GetByIdAsync(fenceId);
            var distance = CalculateDistance(location.Latitude, location.Longitude, fence.CenterLatitude, fence.CenterLongitude);
            return distance <= fence.RadiusMeters;
        }

        public async Task<GeoFenceViolation> RecordViolationAsync(int fenceId, int assetId, string type, double lat, double lng)
        {
            var violation = new GeoFenceViolation
            {
                GeoFenceId = fenceId,
                AssetId = assetId,
                ViolationType = type,
                Latitude = lat,
                Longitude = lng
            };

            await _unitOfWork.Repository<GeoFenceViolation>().AddAsync(violation);
            await _unitOfWork.CompleteAsync();
            return violation;
        }

        public async Task<IEnumerable<GeoFenceViolation>> GetUnacknowledgedViolationsAsync()
        {
            var all = await _unitOfWork.Repository<GeoFenceViolation>().GetAllAsync();
            return all.Where(v => !v.IsAcknowledged).OrderByDescending(v => v.OccurredAt);
        }

        private double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            var R = 6371000;
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLng = (lng2 - lng1) * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
    }
}
