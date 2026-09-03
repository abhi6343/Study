namespace LoginApp.Middlewares
{
    public class LoginMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                using var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();

                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Request Body: {body}");
                await next(context);
            }
            catch
            {
                await Task.CompletedTask;
            }
        }
    }

    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
