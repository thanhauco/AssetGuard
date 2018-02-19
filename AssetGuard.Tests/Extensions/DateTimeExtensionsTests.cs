using Xunit;
using System;
using AssetGuard.Core.Extensions;

namespace AssetGuard.Tests.Extensions
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void IsWeekday_Works()
        {
            var monday = new DateTime(2023, 10, 2); // Monday
            Assert.True(monday.IsWeekday());
        }
    }
}
