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
        [Route("SignUp")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUpResident(NewResident newResident)
        {
            var response = await residentService.SignUpResident(newResident);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Activate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActivateResident(NewResident newResident)
        {
            var response = await residentService.ActivateResident(newResident);
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }

        [HttpPost]
        [Route("Deactivate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeactivateResident(NewResident newResident)
        {
            var response = await residentService.DeactivateResident(newResident);
            return StatusCode(_defaultResponseWithStatusCode.StatusCode, _defaultResponseWithStatusCode.ApiResponse);
        }
    }
}
