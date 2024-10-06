namespace Maiguard.Core.Models.APIResponseModels
{
    /// <summary>
    /// Base model for successful responses
    /// </summary>
    public record ApiResponse
    {
        /// <summary>
        /// API response message
        /// </summary>
        public required string Message { get; set; }

        /// <summary>
        /// API response data
        /// </summary>
        public required object Data { get; set; }
    }
}