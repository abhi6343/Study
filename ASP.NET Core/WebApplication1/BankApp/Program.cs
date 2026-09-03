var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Welcome to the Best Bank");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
