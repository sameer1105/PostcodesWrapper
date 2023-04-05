using PostcodesWrapper.Models;
using System.Net;

namespace PostcodesWrapper.CustomMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next; 
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {

                await HandleExceptionAsyn(context);
            }
        }

        private Task HandleExceptionAsyn(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error"
            }.ToString());
        }
    }
}
