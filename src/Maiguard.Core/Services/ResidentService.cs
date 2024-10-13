using FluentValidation;
using FluentValidation.Results;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Factories;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            int result = _residentRepository.ActivateResident(request);

            switch (result)
            {
                case 4000:
                    return _apiResponseFactory.DuplicateRecord("Resident has not been verified.");

                case 5000:
                    return _apiResponseFactory.DuplicateRecord("Resident is already active.");

                case 1:
                    return _apiResponseFactory.Success("Resident activation successful!", result);

                default:
                    return _apiResponseFactory.InternalServerError();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> DeactivateResident(ResidentDeactivationRequest request)
        {
            int result = _residentRepository.DeactivateResident(request);

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
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ApiResponseWithStatusCode> GenerateInvitationCode(InvitationCodeGenerationRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> RegisterResident(ResidentRegistrationRequest newResident)
        {
            string communityId = newResident.CommunityId;
            string residentId = ResidentUtilities.GenerateResidentId(communityId);

            int result = _residentRepository.AddResident(newResident, residentId);

            while (result == 1000)
            {
                residentId = ResidentUtilities.GenerateResidentId(communityId);
                result = _residentRepository.AddResident(newResident, residentId);
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
