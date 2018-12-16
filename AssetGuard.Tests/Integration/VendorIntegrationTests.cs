using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetGuard.Data;
using AssetGuard.Services.Services;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Integration 
{ 
    public class VendorIntegrationTests 
    { 
        [Fact] 
        public async Task CreateVendor_Persists() 
        { 
            var options = new DbContextOptionsBuilder<AssetGuardContext>()
                .UseInMemoryDatabase(databaseName: "VendorDb_Int_1")
                .Options;

            using (var context = new AssetGuardContext(options))
            {
                var uow = new UnitOfWork(context);
                var service = new VendorService(uow);
                await service.CreateVendorAsync(new VendorDto { Name = "NewVendor" });
            }

            using (var context = new AssetGuardContext(options))
            {
                var v = await context.Vendors.FirstOrDefaultAsync(x => x.Name == "NewVendor");
                Assert.NotNull(v);
            }
        } 
    } 
}
