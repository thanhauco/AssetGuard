using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class VendorValidatorTests
    {
        private readonly VendorValidator _validator = new VendorValidator();

        [Fact]
        public void Should_Verify_Email()
        {
            var model = new Vendor { Email = "not-email" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
