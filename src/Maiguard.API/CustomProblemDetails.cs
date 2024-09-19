using Microsoft.AspNetCore.Mvc;

namespace Maiguard.API
{
    public class CustomProblemDetails : ProblemDetails
    {
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; } = string.Empty;
    }
}
