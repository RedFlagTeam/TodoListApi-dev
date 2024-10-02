using Newtonsoft.Json;
using System.Net;
using MyPublicAPI.Exceptions;

namespace MyPublicAPI.Middleware
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            // Determine the status code
            var statusCode = exception switch
            {
                CompanyNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            response.StatusCode = (int)statusCode;
            return response.WriteAsync(result);
        }
    }
}