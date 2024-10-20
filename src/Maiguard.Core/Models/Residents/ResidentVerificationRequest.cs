using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for verifying a resident account
    /// </summary>
    public class ResidentVerificationRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI0001</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Verification code
        /// </summary>
        /// <example>145893</example>
        public string VerificationCode { get; set; } = string.Empty;
    }
}
