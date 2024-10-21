using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maiguard.Core.Constants
{
    /// <summary>
    /// </summary>
    public static class ValidationMessages
    {
        /// <summary>
        /// </summary>
        public const string IsRequired = "Value for {PropertyName} is required";
        
        /// <summary>
        /// </summary>
        public const string RegexNotMatched = "Value for {PropertyName} must match the following regex: ";

        /// <summary>
        /// </summary>
        public const string RequiredLengthForDigitsNotProvided = "Value for {PropertyName} must contain exactly {MinLength} digits";

        /// <summary>
        /// </summary>
        public const string MaximumLengthExceeded = "Value for {PropertyName} must not exceed {MaxLength} characters";

        /// <summary>
        /// </summary>
        public const string MinimumLengthNotMet = "Value for {PropertyName} must contain more than {MinLength} characters";

        /// <summary>
        /// </summary>
        public const string IsNotRequired = "{PropertyName} must be null or empty";

        /// <summary>
        /// </summary>
        public const string IsOutOfRange = "{PropertyName} must be an integer between {From} and {To}";

    }
}