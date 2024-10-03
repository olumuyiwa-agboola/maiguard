using FluentValidation;
using Maiguard.Core.Constants;
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
    public class ResidentActivationRequestValidator : AbstractValidator<ResidentActivationRequest>
    {
        /// <summary>
        /// </summary>
        public ResidentActivationRequestValidator()
        {
            RuleFor(model => model.ActivatedBy).AdminIdValidator();

            RuleFor(model => model.ResidentId).ResidentIdValidator();
        }
    }
}
