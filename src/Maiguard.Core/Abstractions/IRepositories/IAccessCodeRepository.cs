using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Models.APIResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IRepositories
{
    /// <summary>
    /// Defines the contract for the methods that will execute all the data access 
    /// and persistence logic concerning the generation and use of access codes
    /// </summary>
    public interface IAccessCodeRepository
    {
        /// <summary>
        /// Executes the data access and persistence logic for generating an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> GenerateAccessCode(AccessCodeGenerationRequest request);

        /// <summary>
        /// Executes the data access and persistence logic for verifying an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> VerifyAccessCode(AccessCodeVerificationRequest request);

        /// <summary>
        /// Executes the data access and persistence logic for cancelling an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>int</returns>
        public Task<int> CancelAccessCode(AccessCodeCancellationRequest request);
    }
}
