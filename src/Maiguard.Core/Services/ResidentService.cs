using FluentValidation;
using FluentValidation.Results;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Factories;
using Maiguard.Core.Handlers;
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
    /// <param name="_residentRepository"></param>
    /// <param name="_newResidentValidator"></param>
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IApiResponseFactory _apiResponseFactory;
        private readonly IValidator<ResidentRegistrationRequest> _residentRegistrationRequestValidator;

        /// <summary>
        /// </summary>
        /// <param name="residentRepository"></param>
        /// <param name="apiResponseFactory"></param>
        /// <param name="residentRegistrationRequestValidator"></param>
        public ResidentService(IResidentRepository residentRepository, IApiResponseFactory apiResponseFactory,
        IValidator<ResidentRegistrationRequest> residentRegistrationRequestValidator)
        {
            _residentRepository = residentRepository;
            _apiResponseFactory = apiResponseFactory;
            _residentRegistrationRequestValidator = residentRegistrationRequestValidator;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode ActivateResident(ResidentActivationRequest request)
        {
            return _apiResponseFactory.FeatureNotImplemented();
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode DeactivateResident(ResidentDeactivationRequest request)
        {
            return _apiResponseFactory.FeatureNotImplemented();
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> RegisterResident(ResidentRegistrationRequest newResident)
        {
            var (isValid, errors) = await _residentRegistrationRequestValidator.ValidateModelAsync(newResident);

            if (!isValid && errors != null)
            {
                return _apiResponseFactory.FailedValidation(errors);
            }

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
