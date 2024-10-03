namespace Maiguard.Core.Models.Residents
{
    /// <summary>
    /// Model for creating a new resident account
    /// </summary>
    public class ResidentRegistrationRequest
    {
        /// <summary>
        /// Community Id
        /// </summary>
        /// <example>C123456FHADI</example>
        public string CommunityId { get; set; } = string.Empty;

        /// <summary>
        /// First name
        /// </summary>
        /// <example>Olumuyiwa</example>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name
        /// </summary>
        /// <example>Agboola</example>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email address
        /// </summary>
        /// <example>agboolaod@gmail.com</example>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        /// <example>+2348012345678</example>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Address within the community
        /// </summary>
        /// <example>Block 20, Plot 15</example>
        public string RelativeAddress { get; set; } = string.Empty;

        /// <summary>
        /// Community admin Id or "SELF" for self-onboarding
        /// </summary>
        /// <example>SELF</example>
        public string OnboardedBy { get; set; } = string.Empty;
    }
}