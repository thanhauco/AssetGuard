using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class BuildingValidator : AbstractValidator<Building>
    {
        public BuildingValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.SiteId).GreaterThan(0);
        }
    }
}
