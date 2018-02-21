using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class AssetValidatorTests
    {
        private readonly AssetValidator _validator = new AssetValidator();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new Asset { Name = "" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
