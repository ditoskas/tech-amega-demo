using System.Text.Json;

namespace Entities.Api
{
    /// <summary>
    /// Class that will be used by controllers to return a standardize API response.
    /// Represents the response of an API request.
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse(bool isSuccess, object? data = null, string? message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
