using ConfigurationDemo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Supply an object of WeatherApiOptions (with 'weatherapi' section) as a service
builder.Services.Configure<WeatherAPIOptions>(builder.Configuration.GetSection("weatherapi"));

//Load MyOwnConfig.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/config", async context =>
//    {
//        await context.Response.WriteAsync(app.Configuration["mykEY"] + "\n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<string>("Mykey") + "\n");
//        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n");
//    });
//});

app.Run();
