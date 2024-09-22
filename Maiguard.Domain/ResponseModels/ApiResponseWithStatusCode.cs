namespace Maiguard.API
{
    public class ApiResponseWithStatusCode
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public required int StatusCode { get; set; }

        /// <summary>
        /// Object containing response code, response description and response data
        /// </summary>
        public required ApiResponse ApiResponse { get; set; }
    }
}
