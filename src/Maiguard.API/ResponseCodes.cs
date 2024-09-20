namespace Maiguard.API
{
    public class ResponseCodes
    {
        readonly public static Tuple<string, string> Success = new("00", "Success");

        readonly public static Tuple<string, string> NoRecordReturned = new("25", "No record found");

        readonly public static Tuple<string, string> FailedValidation = new("11", "One or more validations failed");

        readonly public static Tuple<string, string> UnprocessableEntity = new("39", "Request could not be processed");
    }
}
