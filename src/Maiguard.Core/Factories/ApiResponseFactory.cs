using FluentValidation;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IRepositories;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Maiguard.Core.Validators;
using Microsoft.AspNetCore.Http;
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
    public class ApiResponseFactory : IApiResponseFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public ApiResponseFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Builds and returns an API response that indicates a successful execution of the request
        /// </summary>
        /// <param name="message">String to be returned as the API response message</param>
        /// <param name="data">Object to be returned as the API response data</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode Success(string message, object? data)
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
        public ApiResponseWithStatusCode FailedValidation(object validationErrors)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string instance = httpContext!.Request!.Path.Value;
            var problemDetails = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.BadRequest,
                Instance = instance,
                Title = "One or more validation errors occured.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            problemDetails.Extensions["errors"] = validationErrors;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.Conflict,
                ApiResponse = problemDetails
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates a record already exists in the database
        /// </summary>
        /// <param name="message">Message to be returned as the ProblemDetail title</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode DuplicateRecord(string message)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string instance = httpContext!.Request!.Path.Value;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.Conflict,
                ApiResponse = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.Conflict,
                    Instance = instance,
                    Title = message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.9",
                }
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates an internal server error occured
        /// </summary>
        /// <param name="message">Message to be returned as the ProblemDetail title</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode InternalServerError(string message = "An error occured.")
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string instance = httpContext!.Request!.Path.Value;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ApiResponse = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = instance,
                    Title = message,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                }
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates that the requested feature has not yet been implemented
        /// </summary>
        /// <param name="message">Message to be returned as the ProblemDetail title</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode FeatureNotImplemented()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string instance = httpContext!.Request!.Path.Value;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.NotImplemented,
                ApiResponse = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.NotImplemented,
                    Instance = instance,
                    Title = "Feature not yet implemented.",
                    Detail = "This feature is yet to be implemented. Contributions to the development of this feature are welcome at https://github.com/olumuyiwa-agboola/maiguard-api",
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                }
            };
        }
    }
}
