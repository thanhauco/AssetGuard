using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class ApplicationUserValidatorTests
    {
        private readonly ApplicationUserValidator _validator = new ApplicationUserValidator();

        [Fact]
        public void Should_Validate_Required_Fields()
        {
            var model = new ApplicationUser { Username = "" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
