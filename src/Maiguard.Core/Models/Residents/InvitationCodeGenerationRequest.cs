using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for generating an invitation code for a resident
    /// </summary>
    public class InvitationCodeGenerationRequest
    {
        /// <summary>
        /// Community Id
        /// </summary>
        /// <example>C123456FHADI</example>
        public string CommunityId { get; set; } = string.Empty;

        /// <summary>
        /// Community admin Id
        /// </summary>
        /// <example>AFHADI01</example>
        public string AdminId { get; set; } = string.Empty;

        /// <summary>
        /// Resident's first name
        /// </summary>
        /// <example>OLUMUYIWA</example>
        public string ResidentFirstName { get; set; } = string.Empty;

        /// <summary>
        /// Resident's last name
        /// </summary>
        /// <example>AGBOOLA</example>
        public string ResidentLastName { get; set; } = string.Empty;

        /// <summary>
        /// Resident's email address
        /// </summary>
        /// <example>agboolaod@gmail.com</example>
        public string ResidentEmail { get; set; } = string.Empty;
    }
}
