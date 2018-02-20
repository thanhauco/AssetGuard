using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs
{
    public class SendNotificationDtoTests
    {
        [Fact]
        public void SendNotificationDto_Properties_Work()
        {
            var dto = new SendNotificationDto { Subject = "Test" };
            Assert.Equal("Test", dto.Subject);
        }
    }
}
