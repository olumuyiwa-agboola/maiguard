namespace Maiguard.API
{
    public record ApiResponse
    {
        /// <summary>
        ///  API response code
        /// </summary>
        public required string ResponseCode { get; set; }

        /// <summary>
        /// Short description of API response code
        /// </summary>
        public required string ResponseDescription { get; set; }

        /// <summary>
        /// API response data
        /// </summary>
        public object? Data { get; set; }
    }
}
