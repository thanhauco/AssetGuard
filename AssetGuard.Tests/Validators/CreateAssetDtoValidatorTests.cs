using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Services.DTOs;
using FluentValidation.TestHelper;

namespace AssetGuard.Tests.Validators
{
    public class CreateAssetDtoValidatorTests
    {
        private readonly CreateAssetDtoValidator _validator = new CreateAssetDtoValidator();

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new CreateAssetDto { Name = "" };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
