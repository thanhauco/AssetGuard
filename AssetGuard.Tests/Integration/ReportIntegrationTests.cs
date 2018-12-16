using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetGuard.Data;
using AssetGuard.Services.Services;
using AssetGuard.Services.DTOs;
using System.Linq;

namespace AssetGuard.Tests.Integration 
{ 
    public class ReportIntegrationTests 
    { 
        [Fact] 
        public async Task DashboardMetrics_CalculatesCorrectly() 
        { 
            var options = new DbContextOptionsBuilder<AssetGuardContext>()
                .UseInMemoryDatabase(databaseName: "ReportDb_Int_1")
                .Options;

            using (var context = new AssetGuardContext(options))
            {
                context.Assets.Add(new Core.Entities.Asset { Name = "A1" });
                context.Assets.Add(new Core.Entities.Asset { Name = "A2" });
                context.SaveChanges();
            }

            using (var context = new AssetGuardContext(options))
            {
                var uow = new UnitOfWork(context);
                var service = new ReportingService(uow);
                var metrics = await service.GetDashboardMetricsAsync();
                
                Assert.Equal(2, metrics.TotalAssets);
            }
        } 
    } 
}
