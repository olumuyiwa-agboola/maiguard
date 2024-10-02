using FluentValidation;
using FluentValidation.Results;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Factories;
using Maiguard.Core.Handlers;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Utilities;
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
    public class ResidentService(IResidentRepository _residentRepository,
        IValidator<NewResident> _newResidentValidator) : IResidentService
    {
        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<string> ActivateResident(NewResident newResident)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns></returns>
        public async Task<ApiResponseWithStatusCode> SignUpResident(NewResident newResident)
        {
            var (isValid, errors) = await _newResidentValidator.ValidateModelAsync(newResident);

            if (!isValid && errors != null)
            {
                return ApiResponseFactory.FailedValidation(errors);
            }

            string communityId = newResident.CommunityId;
            string residentId = ResidentUtilities.GenerateResidentId(communityId);

            int result = _residentRepository.InsertNewResident(newResident, residentId);

            while (result == 1000)
            {
                residentId = ResidentUtilities.GenerateResidentId(communityId);
                result = _residentRepository.InsertNewResident(newResident, residentId);
            }

            switch (result)
            {
                case 2000:
                    return ApiResponseFactory.DuplicateRecord("Email address already exists.");

                case 3000:
                    return ApiResponseFactory.DuplicateRecord("Phone number already exists.");

                case 1:
                    return ApiResponseFactory.Success("Resident account opened successfully!", newResident);

                default:
                    return ApiResponseFactory.InternalServerError();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<string> DeactivateResident(NewResident newResident)
        {
            throw new NotImplementedException();
        }
    }
}
