using FluentValidation;
using Maiguard.Core.Libraries;
using Maiguard.Core.Models.Residents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Validators
{
    /// <summary>
    /// </summary>
    public class InvitationCodeGenerationRequestValidator : AbstractValidator<InvitationCodeGenerationRequest>
    {
        /// <summary>
        /// </summary>
        public InvitationCodeGenerationRequestValidator()
        {
            RuleFor(model => model.CommunityId).CommunityIdValidator();

            RuleFor(model => model.ResidentFirstName).NameValidator();

            RuleFor(model => model.ResidentLastName).NameValidator();

            RuleFor(model => model.ResidentEmail).EmailValidator();

            RuleFor(model => model.AdminId).AdminIdValidator();
        }
    }
}
