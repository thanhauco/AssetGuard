using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class LoginRequestTests
    {
        [Fact]
        public void LoginRequest_Properties_Work()
        {
            var dto = new LoginRequest { Username = "Test" };
            Assert.Equal("Test", dto.Username);
        }
    }
}
