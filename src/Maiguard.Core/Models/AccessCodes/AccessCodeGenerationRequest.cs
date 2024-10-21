using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.AccessCodes
{
    /// <summary>
    /// Model for generating an access code
    /// </summary>
    public class AccessCodeGenerationRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI0001</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Visitor's name
        /// </summary>
        /// <example>John Doe</example>
        public string VisitorsName { get; set; } = string.Empty;

        /// <summary>
        /// Community Id
        /// </summary>
        /// <example>C000001FHADI</example>
        public string CommunityId { get; set; } = string.Empty;

        /// <summary>
        /// Validity period in hours
        /// </summary>
        /// <example>1</example>
        public int Validity { get; set; }
    }
}
