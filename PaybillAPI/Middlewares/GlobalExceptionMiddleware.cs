using System.Net;
using System.Text.Json;

namespace Paybill.Middlewares
{
    public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                context.Response.Headers.Server = "no-server";
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during executing {Path}", context.Request.Path.Value);
                if (context.Request.Path.StartsWithSegments("/api") ||
                    context.Request.Headers.Accept.ToString().Contains("application/json", StringComparison.OrdinalIgnoreCase))
                {
                    await HandleExceptionAsync(context, ex);
                }
                else
                {
                    throw;
                }
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (!ex.Message.Contains("An item with the same key has already been added"))
                return context.Response.WriteAsync(JsonSerializer.Serialize(new { message = ex.Message, stackTrack = ex.StackTrace, context.Response.StatusCode }));
            else
                return context.Response.WriteAsync(JsonSerializer.Serialize(new { message = "Oops! Something went wrong. Try again please!", stackTrack = ex.StackTrace, context.Response.StatusCode }));
        }
    }

    public static class GlobalExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
