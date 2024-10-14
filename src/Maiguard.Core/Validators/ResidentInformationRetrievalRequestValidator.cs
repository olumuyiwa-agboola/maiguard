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
    public class ResidentInformationRetrievalRequestValidator : AbstractValidator<ResidentInformationRetrievalRequest>
    {
        /// <summary>
        /// </summary>
        public ResidentInformationRetrievalRequestValidator()
        {
            RuleFor(model => model.ResidentId).ResidentIdValidator();
        }
    }
}
