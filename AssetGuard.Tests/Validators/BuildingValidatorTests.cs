using Xunit;
using AssetGuard.Services.Validators;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Validators
{
    public class BuildingValidatorTests
    {
        private readonly BuildingValidator _validator = new BuildingValidator();

        [Fact]
        public void Should_Error_Without_SiteId()
        {
            var model = new Building { SiteId = 0 };
            var result = _validator.Validate(model);
            Assert.False(result.IsValid);
        }
    }
}
