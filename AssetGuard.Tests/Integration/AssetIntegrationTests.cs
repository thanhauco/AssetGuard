using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetGuard.Data;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Integration 
{ 
    public class AssetIntegrationTests 
    { 
        [Fact] 
        public async Task CreateRetrieve_Asset_Works() 
        { 
            var options = new DbContextOptionsBuilder<AssetGuardContext>()
                .UseInMemoryDatabase(databaseName: "AssetDb_Int_1")
                .Options;

            // Seed
            using (var context = new AssetGuardContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // Act
            using (var context = new AssetGuardContext(options))
            {
                var uow = new UnitOfWork(context);
                var service = new AssetService(uow);
                
                await service.CreateAssetAsync(new AssetDto { Name = "IntTest", SerialNumber = "111" });
            }

            // Assert
            using (var context = new AssetGuardContext(options))
            {
                var asset = await context.Assets.FirstOrDefaultAsync(a => a.Name == "IntTest");
                Assert.NotNull(asset);
                Assert.Equal("111", asset.SerialNumber);
            }
        } 
    } 
}
