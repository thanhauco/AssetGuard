using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure
{
    public class NotFoundExceptionTests
    {
        [Fact]
        public void NotFoundException_Message_Works()
        {
            var ex = new NotFoundException("Test");
            Assert.Equal("Test", ex.Message);
        }
    }
}
