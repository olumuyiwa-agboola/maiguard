namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for deactivating a resident account
    /// </summary>
    public class ResidentDeactivationRequest
    {
        /// <summary>
        /// Resident Id
        /// </summary>
        /// <example>RFHADI5188</example>
        public string ResidentId { get; set; } = string.Empty;

        /// <summary>
        /// Community admin Id or "SELF" for self-deactivation
        /// </summary>
        /// <example>SELF</example>
        public string DeactivatedBy { get; set; } = string.Empty;
    }
}
