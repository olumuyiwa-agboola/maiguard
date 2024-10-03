using Maiguard.Core.Models.APIResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Abstractions.IFactories
{
    /// <summary>
    /// </summary>
    public interface IApiResponseFactory
    {
        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode Success(string message, object? data);

        /// <summary>
        /// </summary>
        /// <param name="validationErrors"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode FailedValidation(object validationErrors);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode DuplicateRecord(string message);

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode InternalServerError(string message = "An error occured.");

        /// <summary>
        /// </summary>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode FeatureNotImplemented();
    }
}
