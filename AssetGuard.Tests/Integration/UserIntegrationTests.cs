using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetGuard.Data;
using AssetGuard.Services.Services;
using AssetGuard.Services.DTOs;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AssetGuard.Tests.Integration 
{ 
    public class UserIntegrationTests 
    { 
        [Fact] 
        public async Task Register_CreatesUser() 
        { 
            var options = new DbContextOptionsBuilder<AssetGuardContext>()
                .UseInMemoryDatabase(databaseName: "UserDb_Int_1")
                .Options;

            using (var context = new AssetGuardContext(options))
            {
                var uow = new UnitOfWork(context);
                var configMock = new Mock<IConfiguration>();
                configMock.Setup(c => c["Jwt:Key"]).Returns("SuperSecretKey12345");
                
                var service = new IdentityService(uow, configMock.Object);
                await service.RegisterAsync(new LoginRequest { Username = "newuser", Password = "Password123!" });
            }

            using (var context = new AssetGuardContext(options))
            {
                var user = await context.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == "newuser");
                Assert.NotNull(user);
            }
        } 
    } 
}
