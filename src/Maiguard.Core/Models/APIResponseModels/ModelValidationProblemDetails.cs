using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.APIResponseModels
{
    /// <summary>
    /// </summary>
    public class ModelValidationProblemDetails : ProblemDetails
    {
        /// <summary>
        /// </summary>
        public required object Errors { get; set; }
    }
}
