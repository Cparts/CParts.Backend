using Microsoft.AspNetCore.Mvc;

namespace CParts.Web
{
    public class JsonMessageResult : ObjectResult
    {
        public JsonMessageResult(string message, int statusCode, object value) : base(value)
        {
            StatusCode = statusCode;
            var responseMessage = new JsonResponseMessage
            {
                Message = message,
                StatusCode = statusCode,
                Payload = value
            };
            value = responseMessage;
        }
    }
}