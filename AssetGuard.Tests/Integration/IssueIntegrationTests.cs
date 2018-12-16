using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetGuard.Data;
using AssetGuard.Services.Services;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Integration 
{ 
    public class IssueIntegrationTests 
    { 
        [Fact] 
        public async Task ReportIssue_Persists() 
        { 
            var options = new DbContextOptionsBuilder<AssetGuardContext>()
                .UseInMemoryDatabase(databaseName: "IssueDb_Int_1")
                .Options;

            using (var context = new AssetGuardContext(options))
            {
                var uow = new UnitOfWork(context);
                var service = new IssueService(uow);
                await service.ReportIssueAsync(new CreateIssueDto { Title = "Crash", Description = "App crashed" });
            }

            using (var context = new AssetGuardContext(options))
            {
                var issue = await context.Issues.FirstOrDefaultAsync(i => i.Title == "Crash");
                Assert.NotNull(issue);
            }
        } 
    } 
}
