using Xunit;
using AssetGuard.Core.Extensions;

namespace AssetGuard.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Truncate_Works()
        {
            Assert.Equal("Tes...", "Testing".Truncate(3));
        }
    }
}
