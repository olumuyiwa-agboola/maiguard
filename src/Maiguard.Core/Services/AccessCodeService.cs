using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.AppSettings;
using Maiguard.Core.Enums;
using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Maiguard.Core.Services
{
    /// <summary>
    /// </summary>
    public class AccessCodeService : IAccessCodeService
    {
        private readonly IDistributedCache _redisCache;
        private readonly IResidentRepository _residentRepository;
        private readonly RedisCacheSettings _redisCacheSettings;
        private readonly IApiResponseFactory _apiResponseFactory;

        /// <summary>
        /// </summary>
        /// <param name="apiResponseFactory"></param>
        /// <param name="redisCache"></param>
        /// <param name="redisCacheSettings"></param>
        /// <param name="residentRepository"></param>
        public AccessCodeService(IApiResponseFactory apiResponseFactory, IDistributedCache redisCache,
            IOptions<RedisCacheSettings> redisCacheSettings, IResidentRepository residentRepository)
        {
            _redisCache = redisCache;
            _residentRepository = residentRepository;
            _apiResponseFactory = apiResponseFactory;
            _redisCacheSettings = redisCacheSettings.Value;
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> CancelAccessCode(AccessCodeCancellationRequest request)
        {
            return _apiResponseFactory.FeatureNotImplemented();
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> GenerateAccessCode(AccessCodeGenerationRequest request)
        {
            int validity = request.Validity;
            string residentId = request.ResidentId;
            string communityId = request.CommunityId;
            var accessCodeExpiration = TimeSpan.FromHours(validity);
            string visitorsName = string.Join("", request.VisitorsName.Split(""));

            int residentValidationResponse = await _residentRepository.ValidateResidentId(residentId, communityId);

            if (residentValidationResponse != (int)DbResponses.Success)
                return _apiResponseFactory.HandleDbResponse(residentValidationResponse, null);

            string communityName = string.Empty;
            string residentAddress = string.Empty;
            string accessCodeExpirationDateTime = string.Empty;

            string accessCodeCacheKey = $"ACC-CODE_{residentId}_{visitorsName}";

            string accessCode = await _redisCache.GetRecordAsync<string>(accessCodeCacheKey) ?? "";
             
            if (!string.IsNullOrEmpty(accessCode))
            {
                accessCode = AccessCodeUtility.GenerateAccessCode();
                await _redisCache.SetRecordAsync(accessCodeCacheKey, accessCode, accessCodeExpiration);
            }

            AccessCodeGenerationResponseData responseData = new()
            {
                CommunityId = communityId,
                ExpiresBy = accessCodeExpirationDateTime,
                Message = $"Dear {visitorsName},\n\nYour one-time access code to {communityName} is {accessCode}, valid till {accessCodeExpirationDateTime}.\n\nYour destination is at {residentAddress}.\n\nEnjoy your stay!",
                ResidentId = residentId,
                VisitorsName = visitorsName
            };

            return _apiResponseFactory.Success("Access code generated successfully", responseData);
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public async Task<ApiResponseWithStatusCode> VerifyAccessCode(AccessCodeVerificationRequest request)
        {
            return _apiResponseFactory.FeatureNotImplemented();
        }
    }
}
