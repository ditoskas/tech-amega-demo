using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entities.Api
{
    /// <summary>
    /// Class that will be used by controllers to return a standardize API response.
    /// </summary>
    public class ApiResult : ActionResult
    {
        private readonly ApiResponse _response;
        protected int? StatusCodeToSend { get; set; }

        public ApiResult(object? data = null)
        {
            _response = new ApiResponse(true, data);
        }
        public ApiResult(int? statusCode = 200, object? data = null, string? message = "")
        {
            bool isSuccess = statusCode >= 200 && statusCode < 300;
            _response = new ApiResponse(isSuccess, data, message);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_response)
            {
                StatusCode = StatusCodeToSend ?? StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
