using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure
{
    public class BadRequestExceptionTests
    {
        [Fact]
        public void BadRequestException_Message_Works()
        {
            var ex = new BadRequestException("Test");
            Assert.Equal("Test", ex.Message);
        }
    }
}
