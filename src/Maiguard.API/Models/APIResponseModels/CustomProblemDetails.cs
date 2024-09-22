using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API.Models.APIResponseModels
{
    public class CustomProblemDetails : ProblemDetails
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; } = string.Empty;
    }
}
