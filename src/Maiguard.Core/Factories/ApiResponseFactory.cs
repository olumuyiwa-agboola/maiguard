﻿using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Enums;
using Maiguard.Core.Models.APIResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="data"></param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode HandleDbResponse(int result, object? data)
        {
            switch (result)
            {
                case (int)DbResponses.PhoneNumberAlreadyExists:
                    return DuplicateRecord("Phone number already exists.");

                case (int)DbResponses.EmailAlreadyExists:
                    return DuplicateRecord("Email already exists.");

                case (int)DbResponses.AdminIdNotValidForCommunity:
                    return DuplicateRecord("AdminId not valid for community.");

                case (int)DbResponses.ResidentNotVerified:
                    return DuplicateRecord("Resident has not been verified.");

                case (int)DbResponses.ResidentAlreadyActive:
                    return DuplicateRecord("Resident is already active.");

                case (int)DbResponses.ResidentAlreadyInactive:
                    return DuplicateRecord("Resident is already inactive.");

                case (int)DbResponses.NoRecordFound:
                    return NoRecordFound("No record found.");

                case (int)DbResponses.Success:
                    return Success("Success", data);

                default:
                    return InternalServerError();
            }
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
                    Data = data ?? ""
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

            //problemDetails.Extensions["errors"] = validationErrors;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.Conflict,
                ApiResponse = problemDetails
            };
        }

        /// <summary>
        /// Builds and returns an API response that indicates that no record was found in the database
        /// </summary>
        /// <param name="message">Message to be returned as the ProblemDetail title</param>
        /// <returns>ApiResponseWithStatusCode</returns>
        public ApiResponseWithStatusCode NoRecordFound(string message = "No record found.")
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string instance = httpContext!.Request!.Path.Value;

            return new ApiResponseWithStatusCode()
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                ApiResponse = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Instance = instance,
                    Title = message,
                    Type = "https://tools.ietf.org/doc/html/rfc7231#section-6.5.4",
                }
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
