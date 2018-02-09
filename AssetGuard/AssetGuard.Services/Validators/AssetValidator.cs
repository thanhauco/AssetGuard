using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class AssetValidator : AbstractValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
