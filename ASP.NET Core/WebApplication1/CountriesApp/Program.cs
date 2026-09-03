using System.Net;

Dictionary<int, string> countries = new()
{
    { 1, "United States" },
    { 2, "Canada" },
    { 3, "United Kingdom" },
    { 4, "India" },
    { 5, "Japan" },
};
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//app.UseRouting();
//app.UseEndpoints(async endpoints =>
//{
//    endpoints.MapGet("countries", async context =>
//    {        
//        foreach (var item in countries)
//        {
//            await context.Response.WriteAsync(item.Key + ", " + item.Value + "\n");
//        }        
//    });

//    endpoints.MapGet("countries/{id:int:range(1,5)}", async context =>
//    {
//        if(int.TryParse(context.Request.RouteValues["id"] as string, out int countryId))
//        {
//            if (countries.TryGetValue(countryId, out string countryName))
//            {
//                await context.Response.WriteAsync($"{countryId}, {countryName}");
//            }
//        }
//        else
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
//            await context.Response.WriteAsync("Country not found");
//        }
//    });

//    endpoints.MapGet("countries/{id:int:range(6,100)}", async context =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
//        await context.Response.WriteAsync("[No Country]");
//    });

//    endpoints.MapGet("countries/{id:int:min(101)}", async context =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        await context.Response.WriteAsync("The CountryID should be between 1 and 100");
//    });
//});

app.MapGet("/countries", ()=>
{
    return Results.Text(string.Join("\n", countries.Select(item => item.Key + ", " + item.Value)), "text/plain");
});

app.MapGet("/countries/{id:int:range(1,5)}", (int id) =>
{
    if (countries.TryGetValue(id, out var countryName))
    {
        return Results.Ok($"{id}, {countryName}");
    }
    return Results.NotFound("Country not found");
});

app.MapGet("/countries/{id:int:range(6,100)}", (int id) =>
{
    return Results.NotFound("[No Country]");
});

app.MapGet("/countries/{id:int:min(101)}", (int id) =>
{
    return Results.BadRequest("The CountryID should be between 1 and 100");
});

app.MapFallback(() =>
{
    return Results.Text("Hello World!", "text/plain");
});

app.Run();


