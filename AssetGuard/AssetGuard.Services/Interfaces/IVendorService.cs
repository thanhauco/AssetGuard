using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetGuard.Services.Interfaces
{
    public interface IVendorService
    {
        Task<IEnumerable<dynamic>> GetAllVendorsAsync();
        Task AddVendorAsync(string name, string contact);
    }
}
