using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using PostcodesWrapper.CustomMiddleware;
using PostcodesWrapper.Models;
using System.Net;

namespace PostcodesWrapper.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"

                        }.ToString());
                    }
                });
            });

        }

        public static void ConfigureCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
