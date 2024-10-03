using FluentValidation;
using Maiguard.Core.Constants;
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

            RuleFor(model => model.FirstName)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(50).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.FirstName).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.FirstName);

            RuleFor(model => model.LastName)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(50).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.LastName).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.LastName);

            RuleFor(model => model.EmailAddress)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.EmailAddress).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.EmailAddress);

            RuleFor(model => model.PhoneNumber).PhoneNumberValidator();

            RuleFor(model => model.RelativeAddress)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.RelativeAddress).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.RelativeAddress);

            RuleFor(model => model.OnboardedBy).AdminIdValidator();
        }
    }
}
