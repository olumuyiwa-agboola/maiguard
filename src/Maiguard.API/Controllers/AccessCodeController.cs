using Azure.Core;
using Maiguard.Core.Abstractions.IFactories;
using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Models.AccessCodes;
using Maiguard.Core.Models.APIResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccessCodeController : ControllerBase
    {
        private readonly IAccessCodeService _accessCodeService;

        public AccessCodeController(IAccessCodeService accessCodeService)
        {
            _accessCodeService = accessCodeService;
        }

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
