using System.Net;

namespace Sheard
{
    public class ApiResult
    {
        public object Result { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ApiResult(object result, HttpStatusCode httpStatusCode = HttpStatusCode.OK, string message = null, List<string> errors = null)
        {
            Result = result;
            HttpStatusCode = httpStatusCode;
            Message = string.IsNullOrEmpty(message) ? "every thinges is ok" : message;
            Errors = errors;
        }
    }
}
