using LoginApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<LoginMiddleware>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.Use(async (context, next) =>
//{
//    if (context.Request.Path == "/" && context.Request.Method == "POST")
//    {
//        if (context.Request.Body.CanRead)
//        {
//            using var reader = new StreamReader(context.Request.Body);
//            var body = await reader.ReadToEndAsync();

//            context.Response.ContentType = "text/plain";
//            await context.Response.WriteAsync($"Request Body: {body}");
//            await next(context);
//        }
//        else
//        {
//            context.Response.StatusCode = 400; // Bad Request
//            await context.Response.WriteAsync("Request body is not readable.");
//        }
//    }
//    else
//    {
//        next(context);
//    }
//});

//app.UseMiddleware<LoginMiddleware>();
//app.UseLoginCustomMiddleware();
app.Run((ctx) => 
{
    return ctx.Response.WriteAsync("No response!");
});
app.Run();
