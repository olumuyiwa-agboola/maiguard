using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Services;

namespace Maiguard.Core.Abstractions.IServices
{
    /// <summary>
    /// Defines the contract for the methods that will execute 
    /// the business logic concerning the accounts of residents
    /// </summary>
    public interface IResidentService
    {
        /// <summary>
        /// Executes the business logic for registering a new resident
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> RegisterResident(ResidentRegistrationRequest request);

        /// <summary>
        /// Executes the business logic for activating a resident
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> ActivateResident(ResidentActivationRequest request);

        /// <summary>
        /// Executes the business logic for deactivating a resident
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> DeactivateResident(ResidentDeactivationRequest request);

        /// <summary>
        /// Executes the business logic for generating an invitation code for a resident
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public Task<ApiResponseWithStatusCode> GenerateInvitationCode(InvitationCodeGenerationRequest request);
    }
}
