using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessCodeController : ControllerBase
    {
        private static readonly string _message = "This feature is yet to be implemented. Contributions to " +
            "the development of this feature are welcome at https://github.com/olumuyiwa-agboola/maiguard-api";

        private static readonly ApiResponse _defaultResponse = new()
        {
            ResponseCode = ResponseCodes.Success.Item1,
            ResponseDescription = ResponseCodes.Success.Item2,
            Data = _message
        };

        private readonly ApiResponseWithStatusCode _defaultResponseWithStatusCode = new()
        {
            StatusCode = StatusCodes.Status200OK,
            ApiResponse = _defaultResponse
        };

        [HttpPost]
        [Route("Generate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }

        [HttpPost]
        [Route("Verify")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult VerifyAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }

        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult CancelAccessCode()
        {
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }
    }
}
