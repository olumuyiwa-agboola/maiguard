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
        /// <example>RFHADI5188</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Verification code
        /// </summary>
        /// <example>123456</example>
        public string VerificationCode { get; set; } = string.Empty;
    }
}
