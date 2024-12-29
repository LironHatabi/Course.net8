namespace Course.net8.MiddleWare;

public class FirstMiddleware
{
    private readonly RequestDelegate _next;

    public FirstMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
    {
        
        await context.Response.WriteAsync("from first middleware    A");
        await _next(context);
        await context.Response.WriteAsync("from first middleware    B");
    }
}
    public static class FirstMiddlewareExtensions
    {
        public static  IApplicationBuilder UseFirstMiddleware( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
        
    } 
