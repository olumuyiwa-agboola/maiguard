using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccessCodeController : ControllerBase
    {
        private readonly string _message = "This feature is yet to be implemented. Contributions to the development of this feature are welcome at https://github.com/olumuyiwa-agboola/maiguard-api";

        [HttpPost]
        [Route("Generate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult GenerateAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }

        [HttpPost]
        [Route("Verify")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult VerifyAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }

        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(CustomProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult CancelAccessCode()
        {
            return Ok(new
            {
                message = _message
            });
        }
    }
}
