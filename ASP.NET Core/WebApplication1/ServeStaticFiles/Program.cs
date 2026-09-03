using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "Static files"
});
var app = builder.Build();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath + "\\My web root"),
    RequestPath = "//my-web-root"
});
app.MapGet("/", () => "Hello World!");

app.Run();
