using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for requesting for a resident's information
    /// </summary>
    public class GetResidentRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI5188</example>
        [FromQuery]
        public string? ResidentId { get; set; }
    }
    /// <summary>
    /// Model representing a resident
    /// </summary>
    public class Resident
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        public string? ResidentId { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// CommunityName
        /// </summary>
        public string? CommunityName { get; set; }

        /// <summary>
        /// House address
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Registration date
        /// </summary>
        public string? RegistrationDate { get; set; }

        /// <summary>
        ///  Status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        ///  Verification status
        /// </summary>
        public string? VerificationStatus { get; set; }
    }
}
