using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync("Welcome from ASP.NET Core App!");
//});

//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync("This is my first ASP.NET Core App!");
//});

//app.Run(async ctx =>
//{
//    await ctx.Response.WriteAsync("Welcome from ASP.NET Core App!");
//});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Welcome from ASP.NET Core App!");
    await next(context);
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("\n\n");
    await next(context);
});

//app.UseMiddleware<MyMiddleware>();
//app.UseMyMiddleware();
app.UseConventionalMiddleware();

app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorized") && context.Request.Query["IsAuthorized"] == "true",
    app => {
        app.Use((ctx, next) =>
        {
            ctx.Response.WriteAsync("\n\nYou are authorised to access this resource!\n");
            return next(ctx);
        });
    });

app.Run(async ctx =>
{
    await ctx.Response.WriteAsync("This is my first ASP.NET Core App!");
});
app.Run();
