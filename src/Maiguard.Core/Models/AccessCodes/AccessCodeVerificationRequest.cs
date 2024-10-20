using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.AccessCodes
{
    /// <summary>
    /// Model for verifying an access code
    /// </summary>
    public class AccessCodeVerificationRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI0001</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Access code
        /// </summary>
        /// <example>141397</example>
        public string AccessCode { get; set; } = string.Empty;

        /// <summary>
        /// Community Id
        /// </summary>
        /// <example>C000001FHADI</example>
        public string CommunityId { get; set; } = string.Empty;
    }
}
