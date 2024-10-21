using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.AccessCodes
{
    /// <summary>
    /// </summary>
    public class AccessCodeGenerationResponseData
    {
        /// <summary>
        /// </summary>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string CommunityId {  get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string Message {  get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string ExpiresBy {  get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string VisitorsName { get; set; } = string.Empty;
    }
}
