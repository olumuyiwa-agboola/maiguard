namespace Maiguard.Core.Models.APIResponseModels
{
    public record ApiResponse
    {
        /// <summary>
        /// API response message
        /// </summary>
        public required string Message { get; set; }

        /// <summary>
        /// API response data
        /// </summary>
        public object? Data { get; set; }
    }
}