using FluentValidation;
using Maiguard.Core.Libraries;
using Maiguard.Core.Models.Residents;

namespace Maiguard.Core.Validators
{
    /// <summary>
    /// </summary>
    public class ResidentDeactivationRequestValidator : AbstractValidator<ResidentDeactivationRequest>
    {
        /// <summary>
        /// </summary>
        public ResidentDeactivationRequestValidator()
        {
            RuleFor(model => model.DeactivatedBy).AdminIdValidator();

            RuleFor(model => model.ResidentId).ResidentIdValidator();
        }
    }
}
