using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResidentController(IResidentService residentService) : ControllerBase
    {
        [HttpPost]
        [Route("SignUp")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUpResident(ResidentRegistrationRequest request)
        {
            var response = await residentService.RegisterResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Activate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult ActivateResident(ResidentActivationRequest request)
        {
            var response = residentService.ActivateResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Deactivate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public IActionResult DeactivateResident(ResidentDeactivationRequest request)
        {
            var response = residentService.DeactivateResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }
    }
}
