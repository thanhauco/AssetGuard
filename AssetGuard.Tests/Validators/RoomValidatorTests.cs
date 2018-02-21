using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class RoomValidatorTests
    {
        private readonly RoomValidator _validator = new RoomValidator();

        [Fact]
        public void Should_Require_Capacity()
        {
            var model = new Room { Capacity = 0 };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
