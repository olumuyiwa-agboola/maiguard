using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for activating a resident account
    /// </summary>
    public class ResidentActivationRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI0001</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Community admin Id or "SELF" for self-activation
        /// </summary>
        /// <example>SELF</example>
        public string ActivatedBy { get; set; } = string.Empty;
    }
}
