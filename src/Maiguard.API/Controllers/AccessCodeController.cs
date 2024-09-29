using Maiguard.Core.Models.APIResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessCodeController : ControllerBase
    {
        private static readonly string _message = "Feature not available";
        private static readonly string _data = "This feature is yet to be implemented. Contributions to " +
            "the development of this feature are welcome at https://github.com/olumuyiwa-agboola/maiguard-api";

        private static readonly ApiResponse _defaultResponse = new()
        {
            Message = _message,
            Data = _data
        };

        private readonly ApiResponseWithStatusCode _defaultResponseWithStatusCode = new()
        {
            StatusCode = StatusCodes.Status200OK,
            ApiResponse = _defaultResponse
        };

        [HttpPost]
        [Route("Generate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }

        [HttpPost]
        [Route("Verify")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult VerifyAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }

        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult CancelAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }
    }
}
