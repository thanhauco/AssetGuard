using FluentValidation;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Validators
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        public ApplicationUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
