﻿using Maiguard.Core.Abstractions.IServices;
using Maiguard.Core.Attributes;
using Maiguard.Core.Models.APIResponseModels;
using Maiguard.Core.Models.Residents;
using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ResidentController(IResidentService _residentService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetResident(ResidentInformationRetrievalRequest request)
        {
            var response = await _residentService.GetResident(request.ResidentId!);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterResident(ResidentRegistrationRequest request)
        {
            var response = await _residentService.RegisterResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Activate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActivateResident(ResidentActivationRequest request)
        {
            var response = await _residentService.ActivateResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("InvitationCode/Generate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateInvitationCode(InvitationCodeGenerationRequest request)
        {
            var response = await _residentService.GenerateInvitationCode(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }

        [HttpPost]
        [Route("Deactivate")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeactivateResident(ResidentDeactivationRequest request)
        {
            var response = await _residentService.DeactivateResident(request);
            return StatusCode(response.StatusCode, response.ApiResponse);
        }
    }
}
