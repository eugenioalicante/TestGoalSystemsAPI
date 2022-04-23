namespace TestGoalSystemsAPI.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = StatusCode;
            Message = Message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The request sent has errors",
                401 => "You are not authorized for this resource",
                404 => "The requested resource was not found",
                500 => "Server errors occurred",
                _ => string.Empty
            };
        }
    }
}
