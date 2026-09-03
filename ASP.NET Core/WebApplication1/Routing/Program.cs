using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("alphanumeric", typeof(AlphaNumericConstraint));    
});
var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    var endPoint = context.GetEndpoint();
//    await context.Response.WriteAsync($"Endpoint: {endPoint?.DisplayName ?? "No endpoint"}\n");
//    await next(context);
//});

app.UseRouting();
//app.Use(async (context, next) =>
//{
//    var endPoint = context.GetEndpoint();
//    await context.Response.WriteAsync($"Endpoint: {endPoint?.DisplayName ?? "No endpoint"}\n");
//    await next(context);
//});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/Home", async (HttpContext context) =>
//    {
//        await context.Response.WriteAsync("Welcome to the Home page!");
//    });

//    endpoints.MapGet("/Product", async (HttpContext context) =>
//    {
//        await context.Response.WriteAsync("You are in Products page");
//    });

//    endpoints.MapPost("/Product", async (HttpContext context) =>
//    {
//        await context.Response.WriteAsync("A new product created!");
//    });
//});

////app.MapGet("/", () => "Hello World!");

//app.Run(async (HttpContext context) => 
//{
//    await context.Response.WriteAsync("The page you are requesting for is not found");
//});

app.UseEndpoints(endpoint =>
{
    endpoint.MapGet("/Product/{id:int:range(10,1000)}", async (HttpContext context) => //{id=101} {id?} min(10):max(1000)
    {
        if (!context.Request.RouteValues.ContainsKey("id"))
        {
            await context.Response.WriteAsync("You are viewing all products");
            return;
        }
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"You are viewing product with ID: {id}");
    });
    endpoint.MapGet("/Book/Author/{authorname:alpha:length(8)}/{bookid?}", async (HttpContext context) => //minlength(4):maxlength(16) length(4,8)
    {
        if (!context.Request.RouteValues.ContainsKey("bookid"))
        {
            await context.Response.WriteAsync($"You are viewing all books by author: {context.Request.RouteValues["authorname"]}");
            return;
        }
        var id = Convert.ToInt32(context.Request.RouteValues["bookid"]);
        var authorname = context.Request.RouteValues["authorname"]?.ToString();
        await context.Response.WriteAsync($"You are viewing the book with ID: {id} and author: {authorname}");
    });

    endpoint.MapGet("/quarterly-reports/{year:int:min(1999):minlength(4)}/{month}", async (context) => // {month:regex(^(mar|jun|sep|dec)$)}
    {
        var month = context.Request.RouteValues["month"]?.ToString();
        if (!string.IsNullOrEmpty(month) && (month == "mar" || month == "jun" || month == "sep" || month == "dec"))
        {
            await context.Response.WriteAsync($"You are viewing the quarterly report for year: {context.Request.RouteValues["year"]} and month: {month}");
        }
        else
        {
            context.Response.StatusCode = 400; // Bad Request
            await context.Response.WriteAsync("Invalid month. Please use 'mar', 'jun', 'sep', or 'dec'.");
        }
    });

    endpoint.MapGet("/monthly-reports/{month:regex(^([1-9]|1[012])$)}", async (context) =>
    {
        await context.Response.WriteAsync($"You are viewing the monthly report for month: {context.Request.RouteValues["month"]}");
    });

    //YYYY-/.MM-/.DD 1900-01-01 to 2099-12-31
    endpoint.MapGet("/daily-reports/{date:regex(^(19|20)\\d\\d[- / .](0[1-9]|1[012])[- / .](0[1-9]|[12][0-9]|3[01])$)}", async (context) =>
    {
        await context.Response.WriteAsync($"You are viewing the daily report for date: {context.Request.RouteValues["date"]}");
    });

    endpoint.MapGet("/user/{username:alphanumeric}", async (context) =>
    {
        await context.Response.WriteAsync($"You are viewing the profile of user: {context.Request.RouteValues["username"]}");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core App!");
});

app.Run();
