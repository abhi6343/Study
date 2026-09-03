using Controller.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();
var app = builder.Build();
// enable serving files from wwwroot if you return a VirtualFileResult
app.UseStaticFiles();
app.MapControllers();
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();
