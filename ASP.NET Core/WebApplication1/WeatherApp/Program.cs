using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(IWeatherService), typeof(WeatherService), ServiceLifetime.Transient));
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
