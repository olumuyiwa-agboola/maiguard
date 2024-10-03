using FluentValidation;
using Maiguard.Core.Constants;
using Maiguard.Core.Libraries;
using Maiguard.Core.Models.Residents;

namespace Maiguard.Core.Validators
{
    /// <summary>
    /// </summary>
    public class ResidentRegistrationRequestValidator : AbstractValidator<ResidentRegistrationRequest>
    {
        /// <summary>
        /// </summary>
        public ResidentRegistrationRequestValidator()
        {
            RuleFor(model => model.CommunityId).CommunityIdValidator();

            RuleFor(model => model.FirstName).NameValidator();

            RuleFor(model => model.LastName).NameValidator();

            RuleFor(model => model.EmailAddress).EmailValidator();

            RuleFor(model => model.PhoneNumber).PhoneNumberValidator();

            RuleFor(model => model.RelativeAddress).AddressValidator();

            RuleFor(model => model.OnboardedBy).AdminIdValidator();
        }
    }
}
