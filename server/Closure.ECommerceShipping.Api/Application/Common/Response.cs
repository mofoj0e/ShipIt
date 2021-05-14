using System.Collections.Generic;

namespace Closure.ECommerceShipping.Api.Application.Common
{
    public class Response<T>
    {
        public T Result { get; }
        public string ErrorMessage { get; }
        public IDictionary<string, string[]> Errors { get; set; }

        public Response(T result, string errorMessage, IDictionary<string, string[]> errors = null)
        {
            Result = result;
            ErrorMessage = errorMessage;
            Errors = errors;
        }
    }

    public class Response : Response<string>
    {
        protected Response(string errorMessage, IDictionary<string, string[]> errors) : base(string.Empty, errorMessage, errors) { }

        public static Response Error(string errorMessage, IDictionary<string, string[]> errors = null)
        {
            return new(errorMessage, errors);
        }

    }
}