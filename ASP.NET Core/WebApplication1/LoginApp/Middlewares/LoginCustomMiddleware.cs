using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.RegularExpressions;

namespace LoginApp.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginCustomMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path == "/" && context.Request.Method == HttpMethods.Post)
            {
                context.Request.EnableBuffering();
                if (context.Request.Body.CanRead)
                {
                    
                    using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
                    var body = await reader.ReadToEndAsync();
                    context.Request.Body.Position = 0;

                    var formData = QueryHelpers.ParseQuery(body);
                    //using(var d = JsonDocument.Parse(body))
                    //{
                    //    bool hasEmail = d.RootElement.TryGetProperty("email", out var email);
                    //    bool hasPassword = d.RootElement.TryGetProperty("password", out var password);
                    //}
                    //string emailPattern = @"email=(?<email>[^&]+)";
                    //Match emailMatch = Regex.Match(body, emailPattern);
                    //if (emailMatch.Success)
                    //{
                    //    valid = emailMatch.Groups["email"].Value == VALID_EMAIL;
                    //}
                    //else
                    //{
                    //    errors.Add("Invalid input for 'email'");
                    //}

                    //string pwdPattern = @"password=(?<password>[^&]+)";
                    //Match pwd = Regex.Match(body, pwdPattern);
                    //if (pwd.Success)
                    //{
                    //    if (valid)
                    //    {
                    //        valid = pwd.Groups["password"].Value == VALID_PWD;
                    //    }
                    //}
                    //else
                    //{
                    //    errors.Add("Invalid input for 'password'");
                    //}
                    bool hasEmail = formData.TryGetValue("email", out var email);
                    bool hasPassword = formData.TryGetValue("password", out var password);

                    var errors = new List<string>();

                    if (!hasEmail || string.IsNullOrWhiteSpace(email))
                    {
                        errors.Add("Email is required.");
                    }
                    if (!hasPassword || string.IsNullOrWhiteSpace(password))
                    {
                        errors.Add("Password is required.");
                    }
                    if (errors.Count > 0)
                    {
                        context.Response.StatusCode = 400; // Bad Request
                        await context.Response.WriteAsync(string.Join(Environment.NewLine, errors));
                        return;
                    }
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Successful login");
                }
                else
                {
                    context.Response.StatusCode = 400; // Bad Request
                    await context.Response.WriteAsync("Request body is not readable.");
                }
            }
            else
            {
                await next(context);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginCustomMiddleware>();
        }
    }
}
