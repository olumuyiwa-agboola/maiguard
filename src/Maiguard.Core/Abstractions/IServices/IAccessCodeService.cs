using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Models.APIResponseModels;

namespace Maiguard.Core.Abstractions.IServices
{
    /// <summary>
    /// Defines the contract for the methods that will execute the 
    /// business logic concerning the generation and use of access codes
    /// </summary>
    public interface IAccessCodeService
    {
        /// <summary>
        /// Executes the business logic for generating an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> GenerateAccessCode(AccessCodeGenerationRequest request);

        /// <summary>
        /// Executes the business logic for verifying an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> VerifyAccessCode(AccessCodeVerificationRequest request);

        /// <summary>
        /// Executes the business logic for cancelling an access code
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> CancelAccessCode(AccessCodeCancellationRequest request);
    }
}
