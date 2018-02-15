using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<SiteDto>> GetAllSitesAsync();
        Task<SiteDto> GetSiteByIdAsync(int id);
    }
}
