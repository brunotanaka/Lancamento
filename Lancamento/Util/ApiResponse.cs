using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Lancamento.Util
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Success = statusCode >= 200 && statusCode <= 204 ? true : false;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Success";
                case 201:
                    return "Created";
                case 204:
                    return "Updated";
                case 400:
                    return "Bad Request";
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }

    public class ApiBadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public ApiBadRequestResponse(string error)
            : base(400)
        {
            Errors = new List<string>() { error }.ToArray();
        }

        public ApiBadRequestResponse(List<string> errors)
            : base(400)
        {
            Errors = errors.ToArray();
        }

        public ApiBadRequestResponse(IList<ValidationFailure> errors)
            : base(400)
        {
            Errors = errors.Select(x => x.ErrorMessage).ToArray();
        }
    }

    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(int statusCode, object result, string message = null)
            : base(statusCode, message)
        {
            Result = result;
        }

        public ApiOkResponse(object result)
            : base(200)
        {
            Result = result;
        }
    }

    public class ApiCreatedResponse : ApiOkResponse
    {
        public ApiCreatedResponse(object entity, string message = null)
            : base(201, entity, message)
        {

        }
    }

    public class ApiNotFoundResponse : ApiOkResponse
    {
        public ApiNotFoundResponse(object entity, string message = null)
            : base(404, entity, message)
        {

        }
    }
}
