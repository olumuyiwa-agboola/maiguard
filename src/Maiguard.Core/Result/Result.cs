
namespace Maiguard.Core.Result
{
    public class Result<T>
    {
        #region Public properties
        public T Value { get; set; }

        public Error? Error { get; set; }

        public bool IsSuccess { get; set; }

        #endregion
    }

    public class Error
    {
        public ErrorType Type { get; set; }

        public string Detail { get; set; }
    }
}
