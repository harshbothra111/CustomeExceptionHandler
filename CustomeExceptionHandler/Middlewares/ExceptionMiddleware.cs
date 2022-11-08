using CustomeExceptionHandler.Models;
using CustomeExceptionHandler.Services.Logger;
using System.Net;

namespace CustomeExceptionHandler.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger, IHostEnvironment env)
        {
            _logger = logger;
            _next = next;
            _env = env;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleException(httpContext, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorInfo()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = exception.Message,
                ErrorDetails = _env.IsDevelopment() ? exception.StackTrace : "Internal Server Error"
            }.ToString());
        }
    }
}
