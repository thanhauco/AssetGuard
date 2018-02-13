using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class VendorService : IVendorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<dynamic>> GetAllVendorsAsync()
        {
            var vendors = await _unitOfWork.Repository<Vendor>().GetAllAsync();
            return vendors.Select(v => new { v.Id, v.Name, v.VerificationStatus });
        }

        public async Task AddVendorAsync(string name, string contact)
        {
            await _unitOfWork.Repository<Vendor>().AddAsync(new Vendor
            {
                Name = name,
                ContactPerson = contact,
                VerificationStatus = VerificationStatus.Pending
            });
            await _unitOfWork.CompleteAsync();
        }
    }
}
