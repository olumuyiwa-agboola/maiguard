using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Enums;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Utilities;

namespace Maiguard.Core.Services
{
    /// <summary>
    /// </summary>
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IApiResponseFactory _apiResponseFactory;

        /// <summary>
        /// </summary>
        /// <param name="residentRepository"></param>
        /// <param name="apiResponseFactory"></param>
        public ResidentService(IResidentRepository residentRepository, IApiResponseFactory apiResponseFactory)
        {
            _residentRepository = residentRepository;
            _apiResponseFactory = apiResponseFactory;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> ActivateResident(ResidentActivationRequest request)
        {
            int result = await _residentRepository.ActivateResident(request);

            return _apiResponseFactory.HandleDbResponse(result, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> DeactivateResident(ResidentDeactivationRequest request)
        {
            int result = await _residentRepository.DeactivateResident(request);

            switch (result)
            {
                case 4000:
                    return _apiResponseFactory.DuplicateRecord("Resident has not been verified.");

                case 5000:
                    return _apiResponseFactory.DuplicateRecord("Resident is already inactive.");

                case 1:
                    return _apiResponseFactory.Success("Resident deactivation successful!", request);

                default:
                    return _apiResponseFactory.InternalServerError();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> GenerateInvitationCode(InvitationCodeGenerationRequest request)
        {
            // Check whether the AdminId exists for the CommunityId

            // Check whether the email already exists

            // Generate a six-digit invitation code

            // Send invitation code to email

            // Save invitiation code to cache

            // Return response to client

            return _apiResponseFactory.FeatureNotImplemented();
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> RegisterResident(ResidentRegistrationRequest newResident)
        {
            string communityId = newResident.CommunityId;
            string residentId = ResidentUtilities.GenerateResidentId(communityId);

            int result = await _residentRepository.AddResident(newResident, residentId);

            while (result == 1000)
            {
                residentId = ResidentUtilities.GenerateResidentId(communityId);
                result = await _residentRepository.AddResident(newResident, residentId);
            }

            switch (result)
            {
                case 2000:
                    return _apiResponseFactory.DuplicateRecord("Email address already exists.");

                case 3000:
                    return _apiResponseFactory.DuplicateRecord("Phone number already exists.");

                case 1:
                    return _apiResponseFactory.Success("Resident registration successful!", newResident);

                default:
                    return _apiResponseFactory.InternalServerError();
            }
        }
    }
}
