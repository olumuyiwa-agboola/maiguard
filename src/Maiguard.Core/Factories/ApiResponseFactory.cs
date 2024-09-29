using Maiguard.Core.Models.APIResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Maiguard.Core.Factories
{
    /// <summary>
    /// </summary>
    public class ApiResponseFactory
    {
        /// <summary>
        /// Builds and returns an API response that indicates a successful execution of the request
        /// </summary>
        /// <param name="message">String to be returned as the API response message</param>
        /// <param name="data">Object to be returned as the API response data</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public static ApiResponseWithStatusCode Success(string message, object? data)
        {
            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.OK,
                ApiResponse = new ApiResponse()
                {
                    Message = message,
                    Data = data
                }
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates one or more validation errors occured
        /// </summary>
        /// <param name="validationErrors">Validation errors to be returned as the API response data</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public static ApiResponseWithStatusCode FailedValidation(object validationErrors)
        {
            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                ApiResponse = new ModelValidationProblemDetails()
                {
                    Status = (int)HttpStatusCode.BadRequest,
                    Instance = "instance",
                    Title = "One or more validation errors occured.",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Errors = validationErrors
                }
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates an internal server error occured
        /// </summary>
        /// <param name="message">Message to be returned as the ProblemDetail title</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public static ApiResponseWithStatusCode InternalServerError(string message = "An error occured")
        {
            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ApiResponse = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = "instance",
                    Title = message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                }
            };
        }
    }
}
