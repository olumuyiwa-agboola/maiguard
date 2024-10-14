using Microsoft.AspNetCore.Mvc;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for requesting for a resident's information
    /// </summary>
    public class ResidentInformationRetrievalRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI5188</example>
        [FromQuery]
        public string ResidentId { get; set; } = string.Empty;
    }
}
