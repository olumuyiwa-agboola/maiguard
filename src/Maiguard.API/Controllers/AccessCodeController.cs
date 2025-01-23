using Microsoft.AspNetCore.Mvc;
using Maiguard.Core.Attributes;
using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Models.APIResponseModels;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ValidateModel]
    public class AccessCodeController(IAccessCodeService accessCodeService) : ControllerBase
    {
        private readonly IAccessCodeService _accessCodeService = accessCodeService;

        [HttpPost]
        [Route("Generate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateAccessCode(AccessCodeGenerationRequest request)
        {
            var response = await _accessCodeService.GenerateAccessCode(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Verify")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> VerifyAccessCode(AccessCodeVerificationRequest request)
        {
            var response = await _accessCodeService.VerifyAccessCode(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpDelete]
        [Route("Cancel")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CancelAccessCode(AccessCodeCancellationRequest request)
        {
            var response = await _accessCodeService.CancelAccessCode(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }
    }
}
