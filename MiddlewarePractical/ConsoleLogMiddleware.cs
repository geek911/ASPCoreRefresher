namespace MiddlewarePractical;

public class ConsoleLogMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("This is from the separate middleware");
        await next(context);
    }
}