var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", (HttpContext context) =>
//{
//    //if (context.Request.Headers.TryGetValue("User-Agent", out var userAgent))
//    //{
//    //    return $"User-Agent: {userAgent}";
//    //}
//    //else
//    //{
//    //    return "User-Agent header not found.";
//    //}
//    context.Response.Headers["Content-Type"] = "text/html";
//    context.Response.Headers["MyHeader"] = "Hello World!";
//    return "<h2>This is my first ASP.NET Core app!</h2>";
//    //var path = context.Request.Path;
//    //var method = context.Request.Method;
//    //context.Response.StatusCode = 404;
//    ////return "This is my first ASP.NET Core app!";
//    //return $"Request path: {path} Http method: {method}";
//});

app.Run(async (HttpContext context) =>
{
    //await context.Response.WriteAsync("Hello from server!");
    string path = context.Request.Path;
    if (path == "/" || path == "/Home")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Hello from server!");
    }
    else if (path == "/Contact")
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Contact us at contact@example.com");
    }
    else if (path == "/Product") { 
        context.Response.StatusCode = 200;
        if (context.Request.Query.TryGetValue("id", out var id) && context.Request.Query.TryGetValue("name", out var name))
        {
            await context.Response.WriteAsync("You selected the product with ID : " + id + " and Name: " + name);
            return;
        }
        await context.Response.WriteAsync("You are in Products page");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("Page not found");
    }
});

app.Run();
