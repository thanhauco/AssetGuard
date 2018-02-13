using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SiteDto>> GetAllSitesAsync()
        {
            var sites = await _unitOfWork.Repository<Site>().GetAllAsync();
            return sites.Select(s => new SiteDto
            {
                Id = s.Id,
                Name = s.Name,
                FullAddress = $"{s.Address}, {s.City}, {s.Country}",
                BuildingCount = 0 // Needs proper loading
            });
        }

        public async Task<SiteDto> GetSiteByIdAsync(int id)
        {
            var s = await _unitOfWork.Repository<Site>().GetByIdAsync(id);
            if (s == null) return null;
            
            return new SiteDto
            {
                Id = s.Id,
                Name = s.Name,
                FullAddress = $"{s.Address}, {s.City}, {s.Country}",
                BuildingCount = 0
            };
        }
    }
}
