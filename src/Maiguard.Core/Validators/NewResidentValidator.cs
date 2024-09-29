using FluentValidation;
using Maiguard.Core.Constants;
using Maiguard.Core.Models.Residents;

namespace Maiguard.Core.Validators
{
    public class NewResidentValidator : AbstractValidator<NewResident>
    {
        public NewResidentValidator()
        {
            RuleFor(model => model.CommunityId)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(12).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.CommunityId).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.CommunityId);

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

            RuleFor(model => model.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(14).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.PhoneNumber).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.PhoneNumber);

            RuleFor(model => model.RelativeAddress)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.RelativeAddress).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.RelativeAddress);

            RuleFor(model => model.OnboardedBy)
                .NotEmpty().WithMessage(ValidationMessages.PropertyIsRequired)
                .MaximumLength(14).WithMessage(ValidationMessages.MaximumLengthExceeded)
                .Matches(ValidationRegexes.OnboardedBy).WithMessage(ValidationMessages.RegexNotMatched + ValidationRegexes.OnboardedBy);
        }
    }
}
