﻿namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// </summary>
    public class ResidentDeactivationRequest
    {
        /// <summary>
        /// </summary>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// </summary>
        public string DeactivatedBy { get; set; } = string.Empty;
    }
}
