using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class DroneService : IDroneService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DroneService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<DroneFlight> ScheduleFlightAsync(DroneFlight flight)
        {
            await _unitOfWork.Repository<DroneFlight>().AddAsync(flight);
            await _unitOfWork.CompleteAsync();
            return flight;
        }

        public async Task UpdateFlightStatusAsync(int flightId, string status)
        {
            var flight = await _unitOfWork.Repository<DroneFlight>().GetByIdAsync(flightId);
            if(flight != null) { flight.Status = status; await _unitOfWork.CompleteAsync(); }
        }

        public async Task<InspectionImage> UploadImageAsync(int flightId, string url, double lat, double lng)
        {
            var img = new InspectionImage { DroneFlightId = flightId, ImageUrl = url, Latitude = lat, Longitude = lng };
            await _unitOfWork.Repository<InspectionImage>().AddAsync(img);
            await _unitOfWork.CompleteAsync();
            return img;
        }

        public async Task<IEnumerable<Defect>> AnalyzeImageAsync(int imageId) => new List<Defect>();

        public async Task<IEnumerable<Defect>> GetRecentDefectsAsync(int regionId) => new List<Defect>();

        public async Task VerifyDefectAsync(int defectId, bool isReal) { /* verify */ }
    }
}
