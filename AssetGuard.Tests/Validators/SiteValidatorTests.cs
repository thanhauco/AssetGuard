using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class SiteValidatorTests
    {
        private readonly SiteValidator _validator = new SiteValidator();

        [Fact]
        public void Should_Have_Error_When_Address_Empty()
        {
            var model = new Site { Address = "" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
