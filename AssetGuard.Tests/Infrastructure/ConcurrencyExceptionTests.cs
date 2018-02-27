using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure
{
    public class ConcurrencyExceptionTests
    {
        [Fact]
        public void ConcurrencyException_Message_Works()
        {
            var ex = new ConcurrencyException("Test");
            Assert.Equal("Test", ex.Message);
        }
    }
}
