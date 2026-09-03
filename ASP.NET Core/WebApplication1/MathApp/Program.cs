var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Run(async (HttpContext ctx) =>
{
    if (ctx.Request.Method == "GET")
    {
        if (ctx.Request.Query.TryGetValue("firstNumber", out var firstVals) && ctx.Request.Query.TryGetValue("secondNumber", out var secondVals) && ctx.Request.Query.TryGetValue("operation", out var operationVals))
        {
            if (int.TryParse(firstVals[0], out var num1) && int.TryParse(secondVals[0], out var num2))
            {
                var operation = operationVals[0];

                if (operation != null)
                {
                    if (operation == "add" || operation == "+")
                    {
                        await ctx.Response.WriteAsync((num1 + num2).ToString());
                    }
                    else if (operation == "subtract" || operation == "-")
                    {
                        await ctx.Response.WriteAsync((num1 - num2).ToString());
                    }
                    else if (operation == "multiply" || operation == "*")
                    {
                        await ctx.Response.WriteAsync((num1 * num2).ToString());
                    }
                    else if (operation == "divide" || operation == "/")
                    {
                        if (num2 != 0)
                        {
                            await ctx.Response.WriteAsync((num1 / num2).ToString());
                        }
                        else
                        {
                            await ctx.Response.WriteAsync("Cannot divide by zero.");
                        }
                    }
                    else if (operation == "modulo" || operation == "%")
                    {
                        if (num2 != 0)
                        {
                            await ctx.Response.WriteAsync((num1 % num2).ToString());
                        }
                        else
                        {
                            ctx.Response.StatusCode = 400; // Bad Request
                            await ctx.Response.WriteAsync("Cannot divide by zero.");
                        }
                    }
                    else
                    {
                        ctx.Response.StatusCode = 400; // Bad Request
                        await ctx.Response.WriteAsync("Invalid operation. Use 'add', 'subtract', 'multiply', or 'divide'.");
                    }
                }
            }
        }
        else
        {
            ctx.Response.StatusCode = 400; // Bad Request
            await ctx.Response.WriteAsync("Please provide 'firstNumber', 'secondNumber', and 'operation' query parameters.");
        }
    }
});

app.Run();
