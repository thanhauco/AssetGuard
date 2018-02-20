using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class LoginResponseTests
    {
        [Fact]
        public void LoginResponse_Properties_Work()
        {
            var dto = new LoginResponse { Token = "Test" };
            Assert.Equal("Test", dto.Token);
        }
    }
}
