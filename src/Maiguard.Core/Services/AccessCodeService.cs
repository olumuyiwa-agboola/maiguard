using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Models.APIResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Services
{
    /// <summary>
    /// </summary>
    public class AccessCodeService : IAccessCodeService
    {
        private readonly IApiResponseFactory _apiResponseFactory;

        /// <summary>
        /// </summary>
        /// <param name="apiResponseFactory"></param>
        public AccessCodeService(IApiResponseFactory apiResponseFactory)
        {
            _apiResponseFactory = apiResponseFactory;
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
            return _apiResponseFactory.FeatureNotImplemented();
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
