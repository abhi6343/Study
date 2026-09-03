using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Conventional Middleware Invoked!\n");
            await next(httpContext);
            await httpContext.Response.WriteAsync("\nConventional Middleware Completed!");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConventionalMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConventionalMiddleware>();
        }
    }
}
