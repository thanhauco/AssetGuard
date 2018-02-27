using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Validators
{
    public class LoginRequestValidatorTests
    {
        private readonly LoginRequestValidator _validator = new LoginRequestValidator();

        [Fact]
        public void Should_Have_Error_When_Username_Is_Empty()
        {
            var model = new LoginRequest { Username = null };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
