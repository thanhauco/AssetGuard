using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class SiteValidator : AbstractValidator<Site>
    {
        public SiteValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
