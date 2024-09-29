namespace Maiguard.Core.Models.APIResponseModels
{
    public class ApiResponseWithStatusCode
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public required int StatusCode { get; set; }

        /// <summary>
        /// Object containing API response message and response data
        /// </summary>
        public required object ApiResponse { get; set; }
    }
}
