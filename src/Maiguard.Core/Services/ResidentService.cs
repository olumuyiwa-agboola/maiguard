using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.AppSettings;
using Maiguard.Core.Enums;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Maiguard.Core.Services
{
    /// <summary>
    /// </summary>
    public class ResidentService : IResidentService
    {
        private readonly IDistributedCache _redisCache;
        private readonly RedisCacheSettings _redisCacheSettings;
        private readonly IResidentRepository _residentRepository;
        private readonly IApiResponseFactory _apiResponseFactory;

        /// <summary>
        /// </summary>
        /// <param name="redisCache"></param>
        /// <param name="residentRepository"></param>
        /// <param name="redisCacheSettings"></param>
        /// <param name="apiResponseFactory"></param>
        public ResidentService(IResidentRepository residentRepository, IDistributedCache redisCache, 
            IApiResponseFactory apiResponseFactory, IOptions<RedisCacheSettings> redisCacheSettings)
        {
            _redisCache = redisCache;
            _residentRepository = residentRepository;
            _apiResponseFactory = apiResponseFactory;
            _redisCacheSettings = redisCacheSettings.Value;
        }

        /// <summary>
        /// </summary>
        /// <param name="residentId"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> GetResident(string residentId)
        {
            var dbResponse = await _residentRepository.GetResident(residentId);

            return _apiResponseFactory.HandleDbResponse(dbResponse.Item1, dbResponse.Item2);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> ActivateResident(ResidentActivationRequest request)
        {
            int dbResponse = await _residentRepository.ActivateResident(request);

            return _apiResponseFactory.HandleDbResponse(dbResponse, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> DeactivateResident(ResidentDeactivationRequest request)
        {
            int dbResponse = await _residentRepository.DeactivateResident(request);

            return _apiResponseFactory.HandleDbResponse(dbResponse, null);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> GenerateInvitationCode(InvitationCodeGenerationRequest request)
        {
            string communityId = request.CommunityId;
            string residentEmail = request.ResidentEmail;
            var invitationCodeExpiration = TimeSpan.FromMinutes(_redisCacheSettings.InvitationCodeAbsoluteExpiration);

            int validationResponse = await _residentRepository.ValidateAdminIdAndResidentEmail(request);

            if (validationResponse != (int)DbResponses.Success)
                return _apiResponseFactory.HandleDbResponse(validationResponse, null);

            string invitationCodeCacheKey = $"INV-CODE_{residentEmail.ToUpper()}_{communityId.ToUpper()}";
            string? invitationCode = await _redisCache.GetRecordAsync<string>(invitationCodeCacheKey);

            if (invitationCode is default(string))
            {
                invitationCode = ResidentUtility.GenerateInvitationCode();
                await _redisCache.SetRecordAsync(invitationCodeCacheKey, invitationCode, invitationCodeExpiration);
            }

            #region TO DO: Send invitation code to resident's email

            #endregion

            string message = $"An invitation code has been generated and sent to {residentEmail}.";

            return _apiResponseFactory.Success("Success", message);
        }

        /// <summary>
        /// </summary>
        /// <param name="newResident"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> RegisterResident(ResidentRegistrationRequest newResident)
        {
            string communityId = newResident.CommunityId;
            string residentId = ResidentUtility.GenerateResidentId(communityId);

            int dbResponse = await _residentRepository.AddResident(newResident, residentId);

            while (dbResponse == (int)DbResponses.ResidentIdAlreadyExists)
            {
                residentId = ResidentUtility.GenerateResidentId(communityId);
                dbResponse = await _residentRepository.AddResident(newResident, residentId);
            }

            return _apiResponseFactory.HandleDbResponse(dbResponse, null);
        }
    }
}
