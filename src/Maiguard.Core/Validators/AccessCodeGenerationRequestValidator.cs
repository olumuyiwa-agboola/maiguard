using FluentValidation;
using Maiguard.Core.Libraries;
using Maiguard.Core.Models.AccessCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Validators
{
    /// <summary>
    /// </summary>
    public class AccessCodeGenerationRequestValidator : AbstractValidator<AccessCodeGenerationRequest>
    {
        /// <summary>
        /// </summary>
        public AccessCodeGenerationRequestValidator()
        {
            RuleFor(model => model.VisitorsName).NameValidator();

            RuleFor(model => model.ResidentId).ResidentIdValidator();

            RuleFor(model => model.CommunityId).CommunityIdValidator();

            RuleFor(model => model.Validity).AccessCodeValidityPeriodValidator();
        }
    }
}
