namespace Maiguard.API
{
    public class ResponseCodes
    {
        // 00 - 09 - Success response codes
        readonly public static Tuple<string, string> Success = new("00", "Success");

        // 21 - 29 - Data access failure codes
        readonly public static Tuple<string, string> NoRecordReturned = new("25", "No record found");

        // 11 - 19 - Input validation response codes
        readonly public static Tuple<string, string> FailedValidation = new("11", "One or more validations failed");

        // 30 - 39 - Success response codes
        readonly public static Tuple<string, string> UnprocessableEntity = new("39", "Request could not be processed");
    }
}
