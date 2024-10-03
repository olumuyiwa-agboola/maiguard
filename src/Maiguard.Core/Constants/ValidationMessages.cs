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
        public const string PropertyIsRequired = "Value for {PropertyName} is required";
        
        /// <summary>
        /// </summary>
        public const string RegexNotMatched = "Value for {PropertyName} must match the following regex: ";
        
        /// <summary>
        /// </summary>
        public const string MaximumLengthExceeded = "Value for {PropertyName} must not exceed {MaximumLenght} characters";
    }

    /// <summary>
    /// </summary>
    public static class ValidationRegexes
    {
        /// <summary>
        /// </summary>
        public const string EmailAddress = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        
        /// <summary>
        /// </summary>
        public const string RelativeAddress = @"^[A-Za-z0-9.,\- /]+$";
        
        /// <summary>
        /// </summary>
        public const string AdminId = @"^(SELF|A[A-Z]{5}\d{6,})$";

        /// <summary>
        /// </summary>
        public const string ResidentId = @"^R[A-Z]{5}\d{6,}$";

        /// <summary>
        /// </summary>
        public const string CommunityId = @"^C\d{6}[A-Z]+$";

        /// <summary>
        /// </summary>
        public const string PhoneNumber = @"^\+234\d{10,}$";

        /// <summary>
        /// </summary>
        public const string FirstName = @"^[A-Za-z]+$";
        
        /// <summary>
        /// </summary>
        public const string LastName = @"^[A-Za-z]+$";
    }
}